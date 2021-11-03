using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ReaderOptionsApp.Models;

namespace ReaderOptionsApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OidcOptionsController : ControllerBase
    {
        private readonly OidcOptions google, facebook, okta;
        private readonly JwtOptions jwt;
        private readonly SmtpOptions smtp;

        public OidcOptionsController(
                IOptions<SmtpOptions> smtpOptions, 
                IOptionsSnapshot<OidcOptions> oidcOptions, 
                IOptionsMonitor<JwtOptions> jwtOptions)
        {
            smtp = smtpOptions.Value;
            
            google = oidcOptions.Get(OidcProviders.Google);
            facebook = oidcOptions.Get(OidcProviders.Facebook);
            okta = oidcOptions.Get(OidcProviders.Okta);
            
            jwt = jwtOptions.CurrentValue;
        }

        [HttpGet, Route("smtp")]
        public SmtpOptions GetSmtpOptions()
        {
            return smtp;
        }

        [HttpGet, Route("oidc")]
        public Dictionary<string, OidcOptions> GetOidcOptions()
        {
            return new Dictionary<string, OidcOptions>()
            {
                { OidcProviders.Google, google },
                { OidcProviders.Facebook, facebook },
                { OidcProviders.Okta, okta }
            };
        }

        [HttpGet, Route("oidc/{providerName}")]
        public OidcOptions GetOidcOptionsByKey(string providerName)
        {
            switch(providerName)
            {
                case OidcProviders.Google: return google;
                case OidcProviders.Facebook: return facebook;
                case OidcProviders.Okta: return okta;
                default: return null;
            }
        }
    }
}