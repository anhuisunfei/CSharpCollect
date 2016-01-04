using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Tracing;

namespace NLogPractice.Controllers
{
	public class ValueController : ApiController
	{
		private readonly ITraceWriter _tracer;
		public ValueController()
		{

			_tracer = GlobalConfiguration.Configuration.Services.GetTraceWriter(); ;
		}


		public IEnumerable<int> Get()
		{
			_tracer.Info(Request, this.ControllerContext.ControllerDescriptor.ControllerType.FullName, "test");
			return Enumerable.Range(1, 10);
		}

		public int Get(int id)
		{
			int j = 0;
			return 1 / j;
		}
	}
}
