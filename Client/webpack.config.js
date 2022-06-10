require("jsonc-require");
const path = require("path");
const webpack = require("webpack");

const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const CopyPlugin = require("copy-webpack-plugin");
const FileManagerPlugin = require("filemanager-webpack-plugin");

const glob = require("glob");
const exec = require("child_process").exec;
const { merge } = require("webpack-merge");

let themeConfig = require(path.resolve(process.cwd(), "theme.jsonc"));
if (!themeConfig) {
  themeConfig = {
    ThemeName: "ToSic.Oqt.Themes.ToShineBs5",
    OqtaneRoot: "../web",
  };
} else {
  if (!themeConfig.ThemeName)
    themeConfig.ThemeName = "ToSic.Oqt.Themes.ToShineBs5";
  if (!themeConfig.OqtaneRoot) themeConfig.OqtaneRoot = "../web";
}

if (!path.isAbsolute(themeConfig.OqtaneRoot)) {
  themeConfig.OqtaneRoot = `../${themeConfig.OqtaneRoot}`;
}

const commonConfig = {
  mode: "production",
  entry: {
    styles: "./src/scss/theme.scss",
    ambient: glob.sync("./src/ts-ambient/*.ts"),
  },
  output: {
    path: path.resolve(
      __dirname,
      `dist/wwwroot/Themes/${themeConfig.ThemeName}`
    ),
    assetModuleFilename: "images/[hash][ext][query]",
  },
  devtool: "source-map",
  performance: {
    assetFilter: function (assetFilename) {
      return assetFilename.endsWith(".js");
    },
  },
  stats: {
    warnings: false,
    cachedModules: false,
    groupModulesByCacheStatus: false,
  },
  cache: {
    type: "filesystem",
    cacheDirectory: path.resolve(__dirname, ".temp_cache"),
    compression: "gzip",
  },
  resolve: {
    extensions: [".scss"],
  },
  plugins: [
    new MiniCssExtractPlugin({
      filename: "theme.min.css",
    }),
    new webpack.ProgressPlugin(),
    new CopyPlugin({
      patterns: [
        // copy navigation.json etc to dist
        {
          from: "*.json",
          context: "src",
        },
        // copy bootstrap-bundle to dist
        {
          from: "bootstrap.bundle.min.*",
          context: "node_modules/bootstrap/dist/js/",
        },
        {
          from: "**/*",
          to: "Assets",
          context:"Images",
        },
        {
          from: "*.json",
          context: "ThemeSettings",
        }
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
        test: /\.s[ac]ss$/i,
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
                plugins: function () {
                  return [require("autoprefixer")];
                },
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
          options: {
            transpileOnly: true,
          },
        },
      },
    ],
  },
};

const watchConfig = {
  watch: true,
  plugins: [
    // copy dist to to oqtane web dir
    new FileManagerPlugin({
      events: {
        onEnd: {
          copy: [
            {
              source: "dist",
              destination: path.resolve(__dirname, themeConfig.OqtaneRoot),
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
  const config = env.watch
    ? merge(commonConfig, watchConfig)
    : merge(commonConfig, buildConfig);

  return config;
};

new webpack.ProgressPlugin((percentage, message) => {
  console.log(`${(percentage * 100).toFixed()}% ${message}`);
});
