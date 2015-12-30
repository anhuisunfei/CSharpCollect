using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OAuthPractice.Api.DbContext;
using OAuthPractice.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OAuthPractice.Api.Auth
{
	public class AuthRepository : IDisposable
	{
		public AuthContext _context;
		public UserManager<IdentityUser> _usermanager;
		public AuthRepository()
		{
			_context = new AuthContext();
			_usermanager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_context));
		}

		/// <summary>
		/// 创建用户
		/// </summary>
		/// <param name="userModel"></param>
		/// <returns></returns>
		public async Task<IdentityResult> RegisterUser(UserModel userModel)
		{
			IdentityUser user = new IdentityUser
			{
				UserName = userModel.UserName
			};

			var _user = await _usermanager.CreateAsync(user, userModel.PassWord);
			return _user;
		}

		public async Task<IdentityUser> FindUser(string username, string password)
		{

			var _user = await _usermanager.FindAsync(username, password);
			return _user;
		}


		public void Dispose()
		{
			_context.Dispose();
			_usermanager.Dispose();
		}
	}
}