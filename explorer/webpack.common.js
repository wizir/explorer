const path = require('path');
const AssetsPlugin = require('assets-webpack-plugin');


module.exports = {
  entry: {
      main: './Views/Home/index.ts'
  },
  resolve: {
      extensions: ['.js', '.jsx', '.ts', '.tsx']
  },

  plugins:[
      new AssetsPlugin({path: path.resolve(__dirname, 'wwwroot')}),
  ],
  module:{
      rules:[
          {
              test: /\.ts(x?)$/,
              use: 'ts-loader'
          }
      ]
  }  
};
