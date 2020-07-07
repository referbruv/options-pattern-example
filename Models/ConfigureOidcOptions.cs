using System;
using Microsoft.Extensions.Options;

namespace ReaderOptionsApp.Models
{
    public interface IDecryptService
    {
        string Decrypt(string input);
    }

    public class DecryptService : IDecryptService
    {
        public string Decrypt(string input)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(input));
        }
    }

    public class ConfigureOidcOptions : IConfigureNamedOptions<OidcOptions>
    {
        private readonly IDecryptService decrypt;

        public ConfigureOidcOptions(IDecryptService decrypt)
        {
            this.decrypt = decrypt;
        }

        public void Configure(string name, OidcOptions options)
        {
            options.ClientId = this.decrypt.Decrypt(options.ClientId);
            options.ClientSecret = this.decrypt.Decrypt(options.ClientSecret);
        }

        public void Configure(OidcOptions options)
        {
            Configure(Options.DefaultName, options);
        }
    }
}