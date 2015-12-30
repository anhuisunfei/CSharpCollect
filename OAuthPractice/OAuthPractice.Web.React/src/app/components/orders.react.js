var React=require('react'),
	BootStrap=require('react-bootstrap'),
	Input=BootStrap.Input,
	Glyphicon=BootStrap.Glyphicon,
	Well = BootStrap.Well,
	Button=BootStrap.Button;


var OrderItem=React.createClass({
	render:function(){
		var item=this.props.item;
		return ( 
				<tr>
					<td>{item.orderID}</td>
					<td>{item.customerName}</td>
					<td>{item.shipperCity}</td>
					<td>{item.isShipped}</td> 
			   </tr>

			)
	}
})

var Orders=React.createClass({
	getInitialState: function() {
		return { message: 'api not called.',orders:[]}
	},
	handleClick:function(){
		this.setState({message:"calling..." });
		ajaxApiCall(this);
	},
	render:function(){
		var datas=this.state.orders;
		var orders=datas.map(function(item){
			return <OrderItem item={item} key={item.orderID} />
		})
		
		return(
			<div>
				<h4>Orders</h4>
				<Well>
					<Button onClick={this.handleClick}>
							<Glyphicon glyph="play"/>
							&nbsp; getOrders
					</Button>
					
					<table className="table">
						<thead>
							<tr>
								<th>OrderID</th>
								<th>CustomerName</th>
								<th>ShipperCity</th>
								<th>IsShipped</th>
							</tr>
						</thead>
						<tbody>
							{orders}
						</tbody>
					</table>
					{this.state.message}
				</Well>
			</div>
		);
	}
})

var ajaxApiCall=function(component){
	$.ajax({
		url: "http://localhost:63043/api/orders",
		type: 'GET',
		beforeSend: function(xhr) {
			xhr.setRequestHeader('Authorization', 'Bearer ' + sessionStorage.token);
		},
		success: function(data) {
			component.setState({
				orders: data
			});
		},
		error: function(err) {
			component.setState({
				message: err.responseText
			});
		}
	});
}


module.exports=Orders;