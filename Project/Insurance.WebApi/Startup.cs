using System;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;
using Insurance.WebApi;
using TokenAuthenticationInWebAPI.Models;

[assembly: OwinStartup(typeof(TokenAuthenticationInWebAPI.App_Start.Startup))]

namespace TokenAuthenticationInWebAPI.App_Start
{
    // Класс конфигурации сервера авторизации OAuthAuthorizationServer.
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Enable CORS (cross origin resource sharing) for making request using browser from different domains
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                //Путь для генерации токена
                TokenEndpointPath = new PathString("/token"),
                //Время действия токена
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                //Реализация класса проверки данных пользователя, запрашивающего токен
                Provider = new MyAuthorizationServerProvider()
            };
            //Генерация токена
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }
    }
}