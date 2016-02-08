/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers
 * for more information concerning the license and the contributors participating to this project.
 */

using System.Text.Encodings.Web;
using Microsoft.AspNet.Authentication;
using Microsoft.AspNet.Authentication.OAuth;
using Microsoft.AspNet.DataProtection;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AspNet.Security.OAuth.LinkedIn {
    public class MercadoLibreAuthenticationMiddleware : OAuthMiddleware<MercadoLibreAuthenticationOptions>
    {
        public MercadoLibreAuthenticationMiddleware(
            [NotNull] RequestDelegate next,
            [NotNull] MercadoLibreAuthenticationOptions options,
            [NotNull] IDataProtectionProvider dataProtectionProvider,
            [NotNull] ILoggerFactory loggerFactory,
            [NotNull] UrlEncoder encoder,
            [NotNull] IOptions<SharedAuthenticationOptions> externalOptions)
            : base(next, dataProtectionProvider, loggerFactory, encoder, externalOptions, options)
        {
        }

        protected override AuthenticationHandler<MercadoLibreAuthenticationOptions> CreateHandler()
        {
            return new MercadoLibreAuthenticationHandler(Backchannel);
        }
    }
}