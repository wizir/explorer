const path = require('path');
const AssetsPlugin = require('assets-webpack-plugin');
const { CleanWebpackPlugin } = require('clean-webpack-plugin');

module.exports = {
  entry: {
      main: './Views/Home/index.ts'
  },
  resolve: {
      extensions: ['.js', '.jsx', '.ts', '.tsx']
  },
  output:{
      filename: '[name]-[contentHash].js',
      path: path.resolve(__dirname, 'wwwroot')
  },
  plugins:[
      new AssetsPlugin({useCompilerPath: true}),
      new CleanWebpackPlugin()
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
