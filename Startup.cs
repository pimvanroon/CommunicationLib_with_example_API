using Communication;
using Communication.Middleware;
using IdentityService.Contracts;
using IdentityService.Services;

namespace IdentityService
{
        public class Startup
        {
            private readonly IConfigurationRoot configuration;
            private readonly MetadataCollection metadataCollection;
            private const int MinVersion = 1;
            private const int MaxVersion = 1;

            public Startup(IWebHostEnvironment env)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddJsonFile($"appsettings.{Environment.UserName}.json", optional: true)
                    .AddEnvironmentVariables();
                configuration = builder.Build();

                metadataCollection = new MetadataCollection(
                    new[] { typeof(IUserService)},
                    "com.test",
                    MinVersion, MaxVersion
                );
            }

            public void ConfigureServices(IServiceCollection services)
            {
                services.AddMetadataCollection(metadataCollection)
                        .AddTransient<IUserService, UserService>();
            }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app)
            {
                app.UseMiddleware<MetadataEndpointMiddleware>();
                app.UseHttp();

            }
        }
    }

