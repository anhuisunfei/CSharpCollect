using System;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;

using Microsoft.Owin.Security.OAuth;

using Owin;


[assembly: OwinStartup(typeof(OAuthPractice.Api.Startup))]

namespace OAuthPractice.Api
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			// 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888
			var config = new HttpConfiguration();
			WebApiConfig.Register(config);
			app.UseCors(CorsOptions.AllowAll);
			ConfigureOAuth(app);

			app.UseWebApi(config);
		}


		public void ConfigureOAuth(IAppBuilder app)
		{
			OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
			{
				AllowInsecureHttp = true,
				TokenEndpointPath = new PathString("/token"),
				AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
				Provider = new MyOAuthAuthorizationServerProvider() 

			};
			app.UseOAuthAuthorizationServer(options);
			app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
		}
	}
}
