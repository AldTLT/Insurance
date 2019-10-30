using Insurance.WCF;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
namespace TokenAuthenticationInWebAPI.Models
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IAuthService _authService;

        public MyAuthorizationServerProvider()
        {
            _authService = new AuthService();
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var user = _authService.GetUser(context.UserName);
{
                if (user == null)
                {
                    context.SetError("invalid_grant", "E-mail не существует");
                    return;
                }

                if (user.PasswordHash != context.Password)
                {
                    context.SetError("invalid_grant", "Пароль пользователя неверный");
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, user.Name));
                identity.AddClaim(new Claim(ClaimTypes.Email, user.EMail));

                var claimList = new List<Claim>();
                foreach(var role in user.Role)
                {
                    claimList.Add(new Claim(ClaimTypes.Role, role));
                }

                identity.AddClaims(claimList);

                context.Validated(identity);
            }
        }
    }
}