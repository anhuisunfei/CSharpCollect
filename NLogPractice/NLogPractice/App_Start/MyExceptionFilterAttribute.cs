﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.Tracing;

namespace NLogPractice.App_Start
{
	/// <summary>
	/// 自定义异常Filter
	/// </summary>
	public class MyExceptionFilterAttribute : ExceptionFilterAttribute
	{
		public override void OnException(HttpActionExecutedContext actionExecutedContext)
		{
			var trace = GlobalConfiguration.Configuration.Services.GetTraceWriter();
			
			trace.Error(actionExecutedContext.Request, "Controller : " + actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerType.FullName + Environment.NewLine + "Action : " + actionExecutedContext.ActionContext.ActionDescriptor.ActionName, actionExecutedContext.Exception);

			var exceptionType = actionExecutedContext.Exception.GetType();

			if (exceptionType == typeof(ValidationException))
			{
				var resp = new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent(actionExecutedContext.Exception.Message), ReasonPhrase = "ValidationException", };
				throw new HttpResponseException(resp);

			}
			else if (exceptionType == typeof(UnauthorizedAccessException))
			{
				throw new HttpResponseException(actionExecutedContext.Request.CreateResponse(HttpStatusCode.Unauthorized));
			}
			else
			{
				throw new HttpResponseException(actionExecutedContext.Request.CreateResponse(HttpStatusCode.InternalServerError));
			}
		}
	}
}