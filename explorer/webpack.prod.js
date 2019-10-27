const path = require('path');
const merge = require('webpack-merge');
const { CleanWebpackPlugin } = require('clean-webpack-plugin');

const commonConfig = require('./webpack.common');


module.exports = merge(commonConfig, {
    mode: 'production',
    plugins:[
        new CleanWebpackPlugin()
    ],
    output: {
        filename: '[name]-[contentHash].js',
        path: path.resolve(__dirname, 'wwwroot/dist'),
        publicPath: 'dist'
    }
});