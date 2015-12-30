var React = require('react'),
    BootStrap = require('react-bootstrap'),
    Input = BootStrap.Input,
    Button = BootStrap.Button,
    Glyphicon = BootStrap.Glyphicon;


var Login = React.createClass({
    getInitialState: function () {
        return {
            message: '',
            isLoading: false,
            buttonText:'登录',
            buttonStyle:'default'
        }
    },
    handleLogin:function(){
        var username=this.refs.username.getValue();
        var password=this.refs.password.getValue();
        var granttype="password";
        var login = this;
        $.post("http://localhost:63043/token", 'grant_type='+granttype+'&username='+username+'&password='+password, function(data) {
            login.setState({
                isLoading: false,
                buttonText: ' 登录中...',
                buttonStyle: 'success'
            })
            sessionStorage.token = data.access_token;
        }).fail(function(err) {
            login.setState({
                message: err.responseText
            });
        });
    },
    render: function () {
        return (
                <div className="row">
                    <div className="col-lg-5 col-md-5">
                        <Input ref="username" type="text" lable="用户名" placeholder="请输入用户名" />
                    </div>
                     <div className="col-lg-5 col-md-5">
                        <Input ref="password" type="password" lable="密码" placeholder="请输入密码" />
                    </div>
                    <Button onClick={this.handleLogin} bsStyle={this.state.buttonStyle} className="fixedButton">
                        <Glyphicon glyph="off" />
                        {this.state.buttonText}
                    </Button>
                </div>
            )
    }
});


module.exports = Login;