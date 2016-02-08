/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers
 * for more information concerning the license and the contributors participating to this project.
 */

using System;
using AspNet.Security.OAuth.LinkedIn;
using Microsoft.Extensions.Internal;

namespace Microsoft.AspNet.Builder
{
    public static class MercadoLibreAuthenticationExtensions
    {
        public static IApplicationBuilder UseMercadoLibreAuthentication(
            [NotNull] this IApplicationBuilder app,
            [NotNull] MercadoLibreAuthenticationOptions options)
        {
            return app.UseMiddleware<MercadoLibreAuthenticationMiddleware>(options);
        }

        public static IApplicationBuilder UseMercadoLibreAuthentication(
            [NotNull] this IApplicationBuilder app,
            [NotNull] Action<MercadoLibreAuthenticationOptions> configuration)
        {
            var options = new MercadoLibreAuthenticationOptions();
            configuration(options);

            return app.UseMercadoLibreAuthentication(options);
        }
    }
}