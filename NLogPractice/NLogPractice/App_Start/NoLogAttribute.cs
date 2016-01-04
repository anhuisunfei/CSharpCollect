using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLogPractice.App_Start
{
	/// <summary>
	/// 不记录监控接口执行日志
	/// </summary>
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true)]
	public class NoLogAttribute : Attribute
	{

	}
}