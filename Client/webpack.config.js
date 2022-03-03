const path = require('path');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const OptimizeCSSAssetsPlugin = require('optimize-css-assets-webpack-plugin');
const FriendlyErrorsWebpackPlugin = require('friendly-errors-webpack-plugin');
const TerserPlugin = require('terser-webpack-plugin');
const WebpackBar = require('webpackbar');
const FixStyleOnlyEntriesPlugin = require("webpack-fix-style-only-entries");

module.exports = {
    entry: {
        // styles: './src/scss/theme.scss',
        ts: './src/ts-inpage/page-control-2dm.ts'
    },
    output: {
        path: path.resolve(__dirname, 'wwwroot/Themes/ToSic.Oqt.Themes.ToShineBs5'),
        libraryTarget: 'umd',
        library: 'MyLib'
    },
    mode: 'production',
    devtool: 'source-map',
    watch: false,
    stats: {
        all: false,
        assets: true
    },
    resolve: {
        extensions: ['.ts', '.tsx', '.js', '.scss']
    },
    optimization: {
        minimize: false,
        //minimizer: [
        //    new TerserPlugin({
        //        terserOptions: {
        //            output: {
        //                comments: false,
        //            },
        //        },
        //        extractComments: false,
        //    }),
        //    new OptimizeCSSAssetsPlugin({
        //        cssProcessorOptions: {
        //            map: {
        //                inline: false,
        //                annotation: true,
        //            }
        //        }
        //    })
        //],
    },
    plugins: [
        new FixStyleOnlyEntriesPlugin(),
        new MiniCssExtractPlugin({
            filename: 'theme.min.css',
        }),
        new WebpackBar(),
        new FriendlyErrorsWebpackPlugin(),
    ],
    module: {
        rules: [
        //{
        //    test: /\.scss$/,
        //    exclude: /node_modules/,
        //    use: [
        //        MiniCssExtractPlugin.loader,
        //        {
        //            loader: 'css-loader',
        //            options: {
        //                sourceMap: true
        //            }
        //        }, {
        //            loader: 'postcss-loader',
        //            options: {
        //                sourceMap: true,
        //                postcssOptions: {
        //                    plugins: [
        //                        require('autoprefixer')
        //                    ]
        //                }
        //            }
        //        }, {
        //            loader: 'sass-loader',
        //            options: {
        //                sourceMap: true
        //            }
        //        }
        //    ],
        //},
        {
            test: /\.ts$/,
            exclude: /node_modules/,
            use: {
                loader: 'ts-loader',
                // 2022-03-03 2dm - all not having an effect
                // options: {
                //   context: __dirname,
                //   configFile: 'tsconfig.json',
                //   compilerOptions: {
                //     module: "ES6",
                //     target: "ES6"
                //   }
                // }
            }
        },
        //{
        //    test: /\.(png|jpe?g|gif)$/,
        //    use: [{
        //        loader: 'file-loader',
        //        options: {
        //            name: '[name].[ext]',
        //            outputPath: 'images/'
        //        }
        //    }]
        //}
        ],
    },
};