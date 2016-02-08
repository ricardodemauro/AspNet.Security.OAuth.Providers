/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers
 * for more information concerning the license and the contributors participating to this project.
 */

using Microsoft.AspNet.Authentication.OAuth;
using Microsoft.AspNet.Http;

namespace AspNet.Security.OAuth.LinkedIn
{
    /// <summary>
    /// Defines a set of options used by <see cref="LinkedInAuthenticationHandler"/>.
    /// </summary>
    public class MercadoLibreAuthenticationOptions : OAuthOptions
    {
        public MercadoLibreAuthenticationOptions()
        {
            AuthenticationScheme = MercadoLibreAuthenticationDefaults.AuthenticationScheme;
            DisplayName = MercadoLibreAuthenticationDefaults.DisplayName;
            ClaimsIssuer = MercadoLibreAuthenticationDefaults.Issuer;

            CallbackPath = new PathString(MercadoLibreAuthenticationDefaults.CallbackPath);

            AuthorizationEndpoint = MercadoLibreAuthenticationDefaults.AuthorizationEndpoint;
            TokenEndpoint = MercadoLibreAuthenticationDefaults.TokenEndpoint;
            //UserInformationEndpoint = MercadoLibreAuthenticationDefaults.UserInformationEndpoint;
        }
    }
}