var webpack = require('webpack');

module.exports = {
	entry: [
		'./src/app/app.js'
	],
	output: {
		path: __dirname + '/src/dist',
		publicPath: "/js/",
		filename: 'bundle.js'
	},
	module: {
		loaders: [{
			test: /\.jsx?$/,
			loaders: ['jsx?harmony']
		}]
	}
};