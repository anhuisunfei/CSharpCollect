using Microsoft.AspNet.Identity;
using OAuthPractice.Api.Auth;
using OAuthPractice.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace OAuthPractice.Api.Controllers
{
	[RoutePrefix("api/Account")]
	public class AccountController : ApiController
	{
		private AuthRepository _authRepository;
		public AccountController()
		{
			_authRepository = new AuthRepository();
		}


		[AllowAnonymous]
		[Route("Register")]
		public async Task<IHttpActionResult> Register(UserModel user)
		{
			if (ModelState.IsValid == false)
			{
				return BadRequest(ModelState);
			}
			IdentityResult result = await _authRepository.RegisterUser(user);
			IHttpActionResult errorResult = GetErrorResult(result);

			if (errorResult != null)
			{
				return errorResult;
			}

			return Ok();
		}



		protected override void Dispose(bool disposing)
		{
			_authRepository.Dispose();
			base.Dispose(disposing);
		}

		private IHttpActionResult GetErrorResult(IdentityResult result)
		{
			if (result == null)
			{
				return InternalServerError();
			}

			if (!result.Succeeded)
			{
				if (result.Errors != null)
				{
					foreach (string error in result.Errors)
					{
						ModelState.AddModelError("", error);
					}
				}

				if (ModelState.IsValid)
				{
					// No ModelState errors are available to send, so just return an empty BadRequest.
					return BadRequest();
				}

				return BadRequest(ModelState);
			}

			return null;
		}

	}
}
