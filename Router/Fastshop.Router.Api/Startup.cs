using Fastshop.Roteador.Domain;
using Fastshop.Router;
using Fastshop.Router.Api;
using Fastshop.Router.Domain;
using Fastshop.Router.Infra;
using Fastshop.Router.Infra.Repositories;
using Fastshop.Router.Transactions.Commands;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fastshop.Checkout.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(env.ContentRootPath)
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
              .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<Settings>(options =>
            {
                options.ConnectionString
                    = Configuration.GetSection("Mongo:ConnectionString").Value;
                options.Database
                    = Configuration.GetSection("Mongo:Database").Value;
            });

            services.AddSingleton<MongoContext>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<IConcreteGateway, ConcreteGatewayFactory>();
            services.AddTransient<TransactionService, TransactionService>();

            services.AddMvc(opt =>
            {
                opt.Filters.Add(typeof(ValidatorActionFilter));
            }).AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<CreateTransactionAuthorize>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}