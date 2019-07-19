const path = require('path');
const webpack = require('webpack');

entrys = {
    "views/template001/yz": "....(省略前面) /src/views/template001/yz/yz.js", 
    "views/template002/yz": "....(省略前面) /src/views/template002/yz/yz.js"
  }
module.exports = {
    entry: '1.js',//entrys = {"views/template001/yz": "....(省略前面) /src/views/template001/yz/yz.js", "views/template002/yz": "....(省略前面) /src/views/template002/yz/yz.js"}
    output: {
        path: path.resolve(__dirname, 'dist'),
        filename: 'js/[name].[chunkhash:8].js',
        chunkFilename: 'js/[name].[chunkhash:8].js'
    },
    resolve: {
        extensions: ['.js', '.vue', '.json'],
        alias: {
          '@': resolve('src')
        }
      },
    plugins: [
        // 抽出第三方库，命名vendor，不需要加chunkhash，因为他很少变化
        // minChunk 判断哪些模块可以抽出来合并成ventor，这里只要是从node_module出来就抽
        // 注意一定要放在mainfest的前面
        new webpack.optimize.CommonsChunkPlugin({
            name: 'vendor',
            filename: "vendor.js",
            minChunks: function (module, count) {
                // any required modules inside node_modules are extracted to vendor
                return (
                    module.resource &&
                    /\.js$/.test(module.resource) &&
                    module.resource.indexOf(
                        path.join(__dirname, '/node_modules')
                    ) === 0
                )
            }
        }),
        // 抽出mainfest
        new webpack.optimize.CommonsChunkPlugin({
            name: 'manifest',
            filename: 'manifest.js'
        }),
        new MiniCssExtractPlugin({
            filename: utils.assetsPath('css/[name].[contenthash:8].css'),
            chunkFilename: utils.assetsPath('css/[name].[contenthash:8].css')
          }),
          new HtmlWebpackPlugin({
            filename: config.build.index,
            template: 'index.html',
            inject: true,
            //chunks:['manifest','vendor','js/1/]
            favicon: resolve('favicon.ico'),
            title: 'vue-element-admin',
            templateParameters: {
              BASE_URL: config.build.assetsPublicPath + config.build.assetsSubDirectory,
            },
            minify: {
              removeComments: true,
              collapseWhitespace: true,
              removeAttributeQuotes: true
            }
          }),
    ]
}