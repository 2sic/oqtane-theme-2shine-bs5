const glob = require("glob");
const path = require("path");
const exec = require("child_process").exec;
const { merge } = require("webpack-merge");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const OptimizeCSSAssetsPlugin = require("optimize-css-assets-webpack-plugin");
const FriendlyErrorsWebpackPlugin = require("friendly-errors-webpack-plugin");
const TerserPlugin = require("terser-webpack-plugin");
const WebpackBar = require("webpackbar");
const FixStyleOnlyEntriesPlugin = require("webpack-fix-style-only-entries");
const CopyPlugin = require("copy-webpack-plugin");
const FileManagerPlugin = require("filemanager-webpack-plugin");

let themeConfig = require(path.resolve(process.cwd(), "theme.json"));
if (!themeConfig) {
  themeConfig = {
    ThemeName: "ToSic.Oqt.Themes.ToShineBs5",
    OqtaneRootReleativePath: "../website",
  };
} else {
  if (!themeConfig.ThemeName)
    themeConfig.ThemeName = "ToSic.Oqt.Themes.ToShineBs5";

  if (!themeConfig.OqtaneRootReleativePath)
    themeConfig.OqtaneRootReleativePath = "../website";
}

const commonConfig = {
  entry: {
    styles: "./src/scss/theme.scss",
    ambient: glob.sync("./src/ts-ambient/*.ts"),
  },
  output: {
    path: path.resolve(
      __dirname,
      `dist/wwwroot/Themes/${themeConfig.ThemeName}`
    ),
  },
  mode: "production",
  devtool: "source-map",
  performance: {
    assetFilter: function (assetFilename) {
      return assetFilename.endsWith(".js");
    },
  },
  stats: {
    all: false,
    assets: true,
  },
  resolve: {
    extensions: [".scss"],
  },
  optimization: {
    minimize: true,
    minimizer: [
      new TerserPlugin({
        terserOptions: {
          output: {
            comments: false,
          },
        },
        extractComments: false,
      }),
      new OptimizeCSSAssetsPlugin({
        cssProcessorOptions: {
          map: {
            inline: false,
            annotation: true,
          },
        },
      }),
    ],
  },
  plugins: [
    new FixStyleOnlyEntriesPlugin(),
    new MiniCssExtractPlugin({
      filename: "theme.min.css",
    }),
    new WebpackBar(),
    new FriendlyErrorsWebpackPlugin(),
    new CopyPlugin({
      patterns: [
        // copy navigation.js to dist
        {
          from: "*.json",
          context: "src",
        },
        // copy bootstrap-bundle to dist
        {
          from: "bootstrap.bundle.min.*",
          context: "node_modules/bootstrap/dist/js/",
        },
      ],
    }),
    {
      // triggers tsc build before webpack compile, needed for /interop js-files
      apply: (compiler) => {
        compiler.hooks.beforeCompile.tap("BeforeCompilePlugin", () => {
          exec(
            `tsc --outDir dist/wwwroot/Themes/${themeConfig.ThemeName}/interop`,
            (err, stdout, stderr) => {
              if (stdout) process.stdout.write(stdout);
              if (stderr) process.stderr.write(stderr);
            }
          ).on("exit", () => {});
        });
      },
    },
  ],
  module: {
    rules: [
      {
        test: /\.scss$/,
        exclude: /node_modules/,
        use: [
          MiniCssExtractPlugin.loader,
          {
            loader: "css-loader",
            options: {
              sourceMap: true,
            },
          },
          {
            loader: "postcss-loader",
            options: {
              sourceMap: true,
              postcssOptions: {
                plugins: [require("autoprefixer")],
              },
            },
          },
          {
            loader: "sass-loader",
            options: {
              sourceMap: true,
            },
          },
        ],
      },
      {
        test: /\.ts$/,
        exclude: [/node_modules/, /ts-interop/],
        use: {
          loader: "ts-loader",
        },
      },
      {
        test: /\.(png|jpe?g|gif)$/,
        use: [
          {
            loader: "file-loader",
            options: {
              name: "[name].[ext]",
              outputPath: "images/",
            },
          },
        ],
      },
    ],
  },
};

const watchConfig = {
  watch: true,
  plugins: [
    // copy dist to to oqtane website dir
    new FileManagerPlugin({
      events: {
        onEnd: {
          copy: [
            {
              source: "dist",
              destination: path.resolve(
                __dirname,
                `../${themeConfig.OqtaneRootReleativePath}`
              ),
            },
          ],
        },
      },
    }),
  ],
};

const buildConfig = {
  watch: false,
};

module.exports = (env, args) => {
  const config =
    env == "watch"
      ? merge(commonConfig, watchConfig)
      : merge(commonConfig, buildConfig);

  return config;
};
