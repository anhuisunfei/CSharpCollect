using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Tracing;

namespace NLogPractice.App_Start
{
	/// <summary>
	/// 自定义 Action Filter
	/// </summary>
	public class MyActionFilterAttribute : ActionFilterAttribute
	{
		public const string _durationKey = "_actionDuration";
		public ITraceWriter trace = GlobalConfiguration.Configuration.Services.GetTraceWriter();


		public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
		{
			if (!SkipLogging(actionContext))
			{ 
				Stopwatch watch = new Stopwatch();
				actionContext.Request.Properties[_durationKey] = watch;
				watch.Start();
			}
			base.OnActionExecuting(actionContext);
		}

		public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
		{
			if (actionExecutedContext.Request.Properties.ContainsKey(_durationKey))
			{
				var stopWatch = actionExecutedContext.Request.Properties[_durationKey] as Stopwatch;
				if (stopWatch != null)
				{
					stopWatch.Stop();
					var actionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;
					var controllerName = actionExecutedContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
					string log = string.Format("[execution controller：{0} - action：{1} take {2} time.]", controllerName, actionName, stopWatch.Elapsed); 
					trace.Info(actionExecutedContext.Request, "actionDuration", log);
				}
			}
			base.OnActionExecuted(actionExecutedContext);
		}

		private static bool SkipLogging(HttpActionContext actionContext)
		{
			return actionContext.ActionDescriptor.GetCustomAttributes<NoLogAttribute>().Any() || actionContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<NoLogAttribute>().Any();
		}
	}
}