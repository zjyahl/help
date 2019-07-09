npm config set prefix "C:\Users\zjy\nodejs\node_global"
npm config set cache "C:\Users\zjy\nodejs\node_cache"
NODE_PATH "C:\Users\zjy\nodejs\node_global"
npm install -g cnpm --registry=https://registry.npm.taobao.org
path "C:\Users\zjy\nodejs\node_global"

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