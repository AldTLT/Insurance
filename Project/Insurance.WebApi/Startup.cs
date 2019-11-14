using System;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;
using Container;

[assembly: OwinStartup(typeof(Insurance.WebApi.Startup))]

namespace Insurance.WebApi
{
    // Класс конфигурации сервера авторизации OAuthAuthorizationServer.
    public class Startup
    {
        /// <summary>
        /// Метод конфигурации сервера авторизации.
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            var container = new RepositoryContainer();
            var useStub = true;
            container.SetDependency(useStub);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                //Путь для генерации токена
                TokenEndpointPath = new PathString("/token"),
                //Время действия токена
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                //Реализация класса проверки данных пользователя, запрашивающего токен
                Provider = new AuthorizationServerProvider()
            };
            //Генерация токена
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }
    }
}