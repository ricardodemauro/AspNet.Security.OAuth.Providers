/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers
 * for more information concerning the license and the contributors participating to this project.
 */

using Microsoft.AspNet.Authentication;
using Microsoft.AspNet.Authentication.Cookies;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Mvc.Client {
    public class Startup {
        public static void Main(string[] args) {
            var application = new WebApplicationBuilder()
                .UseConfiguration(WebApplicationConfiguration.GetDefault(args))
                .UseStartup<Startup>()
                .Build();

            application.Run();
        }

        public void ConfigureServices(IServiceCollection services) {
            services.AddAuthentication();
            services.AddMvc();

            services.Configure<SharedAuthenticationOptions>(options => {
                options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });
        }

        public void Configure(IApplicationBuilder app) {
            var factory = app.ApplicationServices.GetRequiredService<ILoggerFactory>();
            factory.AddConsole();
            factory.AddDebug();

            app.UseStaticFiles();

            app.UseCookieAuthentication(options => {
                options.AutomaticAuthenticate = true;
                options.AutomaticChallenge = true;
                options.AuthenticationScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.LoginPath = new PathString("/signin");
            });

            //app.UseGoogleAuthentication(options => {
            //    options.ClientId = "560027070069-37ldt4kfuohhu3m495hk2j4pjp92d382.apps.googleusercontent.com";
            //    options.ClientSecret = "n2Q-GEw9RQjzcRbU3qhfTj8f";
            //});

            //app.UseTwitterAuthentication(options => {
            //    options.ConsumerKey = "6XaCTaLbMqfj6ww3zvZ5g";
            //    options.ConsumerSecret = "Il2eFzGIrYhz6BWjYhVXBPQSfZuS4xoHpSSyD9PI";
            //});

            //app.UseGitHubAuthentication(options => {
            //    options.ClientId = "49e302895d8b09ea5656";
            //    options.ClientSecret = "98f1bf028608901e9df91d64ee61536fe562064b";
            //    options.Scope.Add("user:email");
            //});

            app.UseMvc();
        }
    }
}