const path = require('path');
const merge = require('webpack-merge');
const { CleanWebpackPlugin } = require('clean-webpack-plugin');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');

const commonConfig = require('./webpack.common');


module.exports = merge(commonConfig, {
    mode: 'production',
    output: {
        filename: '[name]-[contentHash].js',
        path: path.resolve(__dirname, 'wwwroot/dist'),
        publicPath: 'dist'
    },
    plugins:[
        new MiniCssExtractPlugin({filename: '[name]-[contentHash].css'}),
        new CleanWebpackPlugin()
    ],
    module: {
        rules: [
            {
                test: /\.scss$/,
                use: [
                    MiniCssExtractPlugin.loader,
                    'css-loader',
                    'sass-loader'
                ]
            }
        ]
    }
});