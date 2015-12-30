using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OAuthPractice.Api.Models
{
	public class UserModel
	{
		[Required]
		[Display(Name = "用户名")]
		public string UserName { get; set; }
		[Required]
		[Display(Name = "密码")]
		public string PassWord { get; set; }
		[Required]
		[Display(Name = "确认密码")]
		public string ConfirmPassWord { get; set; }
	}
}