const path = require('path');



module.exports = {
  entry: {
      main: './Views/Home/index.ts'
  },
  devtool: 'source-map',
  resolve: {
      extensions: ['.js', '.jsx', '.ts', '.tsx']
  },
  output:{
      filename: '[name].js',
      path: path.resolve(__dirname, 'wwwroot/js')
  },
  module:{
      rules:[
          {
              test: /\.ts(x?)$/,
              use: 'ts-loader'
          }
      ]
  }  
};
