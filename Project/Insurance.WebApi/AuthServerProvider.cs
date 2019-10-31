using Insurance.WCF;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Insurance.WebApi
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IAuthService _authService;

        public AuthorizationServerProvider()
        {
            _authService = new AuthService();
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //Получить пользователя по email (UserName на самом деле - email)
            var user = _authService.GetUser(context.UserName);
{
                //Если пользователь с данным email не найден
                if (user == null)
                {
                    context.SetError("invalid_grant", "E-mail не существует");
                    return;
                }

                //Если пароль пользователя не совпадает с введеным паролем
                if (user.PasswordHash != context.Password)
                {
                    context.SetError("invalid_grant", "Пароль пользователя неверный");
                    return;
                }

                //Создание утверждений. 
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
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