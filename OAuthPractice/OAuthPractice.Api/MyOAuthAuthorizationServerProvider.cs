using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using OAuthPractice.Api.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OAuthPractice.Api
{
	public class MyOAuthAuthorizationServerProvider : OAuthAuthorizationServerProvider
	{
		public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
		{
			context.Validated();
			return Task.FromResult<object>(null);
		}

		public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
		{
			using (AuthRepository _repo = new AuthRepository())
			{
				IdentityUser user = await _repo.FindUser(context.UserName, context.Password);

				if (user == null)
				{
					context.Rejected();
					context.SetError("invalid_grant", "The user name or password is incorrect.");
					return;
				}
			}

			var identity = new ClaimsIdentity(context.Options.AuthenticationType);
			identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
			identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
			identity.AddClaim(new Claim("sub", context.UserName));

			var props = new AuthenticationProperties(new Dictionary<string, string>
            {
                { 
                    "as:client_id", context.ClientId ?? string.Empty
                },
                { 
                    "userName", context.UserName
                }
            });

			var ticket = new AuthenticationTicket(identity, props);
			context.Validated(ticket);
		}

		public override Task TokenEndpoint(OAuthTokenEndpointContext context)
		{
			foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
			{
				context.AdditionalResponseParameters.Add(property.Key, property.Value);
			}

			return Task.FromResult<object>(null);
		}
	}
}
