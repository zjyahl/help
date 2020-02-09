npm config set prefix "C:\Users\zjy\nodejs\node_global"
npm config set cache "C:\Users\zjy\nodejs\node_cache"
path "C:\Users\zjy\nodejs\node_global"
npm install --registry=https://registry.npm.taobao.org

npm install --global --production windows-build-tools --registry=https://registry.npm.taobao.org


npm --registry https://registry.npm.taobao.org install express
npm config set registry https://registry.npm.taobao.org
npm config get registry
npm info express

npm install -g webpack
npm install --global webpack-cli
npm init
webpack
npm install -g webpack-dev-server
webpack-dev-server --open

npm init
npm install --save-dev webpack
npm install --save-dev webpack-cli
npm install --save-dev webpack-dev-server
npm install --save-dev babel-core babel-loader babel-preset-env
npm install --save-dev style-loader css-loader

node_modules/.bin/webpack app/main.js -o public/bundle.js
npm run-script build


npm install --save-dev vue-cli
vue init webpack Vue-Project

npm install -save moduleName 
//dependencies 运行npm install --production或者注明NODE_ENV变量值为production时，会自动下载模块到node_modules目录中。

npm install -save-dev moduleName //devDependencies 
//devDependencies  运行npm install --production或者注明NODE_ENV变量值为production时，不会自动下载模块到node_modules目录中。

cnpm outdated