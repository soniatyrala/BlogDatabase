
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogDatabase.BLOG.Web
{
    public class Startup
    {
        private readonly string _connectionString;
        public IHostingEnvironment HostingEnvironment { get; set; }
        public IServiceCollection Services { get; private set; }
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            if (env.IsEnvironment("Development"))
            {
                builder.AddApplicationInsightsSettings(developerMode: true);
            }
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();

            _connectionString = Configuration["ConnectionStrings:MsSqlConnection"];
            HostingEnvironment = env;
            Configuration = configuration;
        }
    }
}

