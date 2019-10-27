const merge = require('webpack-merge');

const commonConfig = require('./webpack.common.js');

module.exports = merge(commonConfig, {
   mode: 'development',
   output: {
       filename: '[name].js'
   },
});
