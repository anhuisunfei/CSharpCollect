var React=require('react'),
	ReactDOM=require('react-dom'),
	BootStrap=require('react-bootstrap'),
	Panel=BootStrap.Panel,
	Login=require('./components/login.react'),
	Orders=require('./components/orders.react');


 var App=React.createClass({
 	render:function(){
 		var header=(<h2>WebApi React OAuth</h2>);
 		return(
 			<Panel bsStyle="primary" header={header}>
 				<Login />
 				<Orders />
 			</Panel>
 		);
 	}
 });


 ReactDOM.render(<App />,document.getElementById('app'));