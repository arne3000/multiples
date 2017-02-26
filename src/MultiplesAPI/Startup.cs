using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MultiplesAPI.Models.Data;
using MultiplesAPI.Builders;
using MultiplesAPI.Queries;
using MultiplesAPI.Models.Output;
using MultiplesAPI.Commands;

namespace MultiplesAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ISummaryBuilder, SummaryBuilder>();
            services.AddTransient<IRuleBuilder<Rule, int, string>, ResultBuilder>();
            services.AddTransient<IBuilder<IEnumerable<Rule>, string>, RuleOutputBuilder>();
            services.AddTransient<IBuilder<IEnumerable<int>, SummaryResult>, SummaryResultBuilder>();
            services.AddTransient<IBuilder<IEnumerable<int>, string>, ResultListBuilder>();
            services.AddTransient<ICommandHandler<RuleCommand, Rule>, RuleCommandHandler>();
            services.AddTransient<IQuery<int, IEnumerable<Rule>>, GetRulesApplyingToInteger>();
            services.AddMvc();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
