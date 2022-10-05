require("jsonc-require");
const path = require("path");
const webpack = require("webpack");

const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const RemoveEmptyScriptsPlugin = require("webpack-remove-empty-scripts");
const CopyPlugin = require("copy-webpack-plugin");
const FileManagerPlugin = require("filemanager-webpack-plugin");

const glob = require("glob");
const exec = require("child_process").exec;
const { merge } = require("webpack-merge");

let themeConfig = require(path.resolve(process.cwd(), "build-theme.json"));
if (!themeConfig) {
  themeConfig = {
    ThemeName: "ToSic.Themes.ToShineBs5",
    OqtaneRoot: "../web",
  };
} else {
  if (!themeConfig.ThemeName) themeConfig.ThemeName = "ToSic.Themes.ToShineBs5";
  if (!themeConfig.OqtaneRoot) themeConfig.OqtaneRoot = "../web";
}

if (!path.isAbsolute(themeConfig.OqtaneRoot)) {
  themeConfig.OqtaneRoot = `../${themeConfig.OqtaneRoot}`;
}

const distFolder = `wwwroot/Themes/${themeConfig.ThemeName}`;

const commonConfig = {
  mode: "production",
  entry: {
    styles: "./src/styles/theme.scss",
    ambient: glob.sync("./src/scripts/ambient/*.ts"),
  },
  output: {
    path: path.resolve(__dirname, distFolder),
    // // TODO: probably check this, we moved the images to src/assets
    // // unclear if this does anything...?
    // assetModuleFilename: "Images/[hash][ext][query]",
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
    extensions: [".scss", ".ts", ".js"],
  },
  plugins: [
    new RemoveEmptyScriptsPlugin(), // prevent empty styles.js from being created :( https://www.npmjs.com/package/webpack-remove-empty-scripts
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
          to: "assets",
          context: "src/assets",
        },
        // {
        //   // Temp - unclear what this is for - looks like experimental json copy from Daia, ignore for now
        //   from: "*.json",
        //   context: "ThemeSettingsUi",
        // },
      ],
    }),
    {
      // triggers tsc build the interop independently from before webpack compile
      // needed for /interop js-files
      // these basically bypass webpack and directly let TSC compile this
      apply: (compiler) => {
        compiler.hooks.beforeCompile.tap("BeforeCompilePlugin", () => {
          exec(
            `tsc -p ./src/scripts/interop/tsconfig.json --outDir ${distFolder}/interop`,
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
        test: /\.woff|woff2/,
        type: "asset/resource",
        generator: {
          filename: "Fonts/[hash][ext][query]",
        },
      },
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
        exclude: [/node_modules/, /scripts\/interop/],
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
              source: "wwwroot",
              destination: path.resolve(
                __dirname,
                themeConfig.OqtaneRoot,
                "wwwroot"
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
  const config = env.watch
    ? merge(commonConfig, watchConfig)
    : merge(commonConfig, buildConfig);

  return config;
};

new webpack.ProgressPlugin((percentage, message) => {
  console.log(`${(percentage * 100).toFixed()}% ${message}`);
});
