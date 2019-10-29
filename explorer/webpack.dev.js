const merge = require('webpack-merge');

const commonConfig = require('./webpack.common.js');

module.exports = merge(commonConfig, {
   mode: 'development',
   output: {
       filename: '[name].js',
   },
    devServer:{
        host: '127.0.0.1',
        port: 8080, 
        disableHostCheck: true,
        https: true
    },
    module:{
        rules:[
            {
                test: /\.scss$/,
                use:[
                    'style-loader',
                    'css-loader',
                    'sass-loader'
                ]
            }
        ]
    }
});
