using NLogPractice.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Tracing;
using System.Web.Routing;

namespace NLogPractice
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			GlobalConfiguration.Configure(WebApiConfig.Register);
			GlobalConfiguration.Configuration.Services.Replace(typeof(ITraceWriter), new NLogger());
			GlobalConfiguration.Configuration.Filters.Add(new MyExceptionFilterAttribute());
			GlobalConfiguration.Configuration.Filters.Add(new MyActionFilterAttribute());
		}
	}
}
