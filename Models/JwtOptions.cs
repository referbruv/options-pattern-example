namespace ReaderOptionsApp.Models
{
    public class JwtOptions
    {
        public const string SectionName = "Jwt";
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string SigningKey { get; set; }
        public bool IsValidateAudience { get; set; }
        public bool IsValidateIssuer { get; set; }
        public bool IsValidateLifetime { get; set; }
    }
}