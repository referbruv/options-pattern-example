using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using ReaderOptionsApp.Models;

namespace ReaderOptionsApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Bind Configuration
            var smtp = new SmtpOptions();
            Configuration.Bind(SmtpOptions.SectionName, smtp);
            services.AddSingleton(smtp);

            // Get Configuration
            var smtp1 = Configuration.GetSection(SmtpOptions.SectionName)
                        .Get<SmtpOptions>();
            services.AddSingleton(smtp1);


            services.AddSingleton<IDecryptService, DecryptService>();

            // Options pattern usage
            services.Configure<SmtpOptions>(Configuration.GetSection(SmtpOptions.SectionName));
            
            // Named options usage
            services.Configure<OidcOptions>(OidcProviders.Google, Configuration.GetSection($"{OidcOptions.SectionName}:{OidcProviders.Google}"));
            services.Configure<OidcOptions>(OidcProviders.Facebook, Configuration.GetSection($"{OidcOptions.SectionName}:{OidcProviders.Facebook}"));
            services.Configure<OidcOptions>(OidcProviders.Okta, Configuration.GetSection($"{OidcOptions.SectionName}:{OidcProviders.Okta}"));

            // customizing the options usage
            services.AddSingleton<IConfigureOptions<OidcOptions>, ConfigureOidcOptions>();
            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
