namespace ReaderOptionsApp.Models
{
    public class OidcProviders
    {
        public const string Google = "Google";
        public const string Facebook = "Facebook";
        public const string Okta = "Okta";
    }

    public class OidcOptions
    {
        public const string SectionName = "Oidc";
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}