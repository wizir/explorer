const merge = require('webpack-merge');

const commonConfig = require('./webpack.common.js');

module.exports = merge(commonConfig, {
   mode: 'development',
   output: {
       filename: '[name].js',
   },
    devServer:{
       inline: false,
       proxy: {
           '/ws': {
               target: `ws://localhost:9000`,
           }
       }
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
