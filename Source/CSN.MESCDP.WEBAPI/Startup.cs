using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CTTPB.MESCDP.Application.WebApi.CustomExceptionMiddleware;
using CTTPB.MESCDP.Application.WebApi.Extensions;
using CTTPB.MESCDP.Application.WebApi.Utils;
using CTTPB.MESCDP.Domain.Config;
using CTTPB.MESCDP.Domain.Interfaces.Repositories;
using CTTPB.MESCDP.Infrastructure.Data;
using CTTPB.MESCDP.Infrastructure.IOC;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace CTTPB.MESCDP.WEBAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            //NHibernateHelper._connectionString = Configuration["ConnectionStrings:MES_PROD"];
        }

        public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);
            services.AddAuthentication(IISDefaults.AuthenticationScheme);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddMemoryCache();


            //services.Configure<IISOptions>(o =>
            //{
            //    o.ForwardClientCertificate = false;
            //});


            string[] urls = {"http://localhost:3000",
                "http://localhost:3001",
                "http://localhost:3002",
                "http://dev-isp.CTTPB.com.br",
                "http://homolog-isp.CTTPB.com.br",
                "http://isp.CTTPB.com.br",
                "http://localhost:8080",
                "http://ncp110:9811",
                "http://ncp110n:9815"
            };

            services.AddCors(option =>
            {
                option.AddPolicy("AllowAll", policy => policy.WithOrigins(urls)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                );
            });

            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            })
            .AddJsonOptions(options =>
            {
                var settings = options.SerializerSettings;
                settings.NullValueHandling = NullValueHandling.Ignore;
                settings.Formatting = Formatting.Indented;
                settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                settings.DateTimeZoneHandling = DateTimeZoneHandling.Local;

                // dont mess with case of properties
                if (settings.ContractResolver is DefaultContractResolver resolver) resolver.NamingStrategy = null;
            });

            services.Configure<IntegracaoMassaConfig>(Configuration.GetSection(nameof(IntegracaoMassaConfig)));
            services.Configure<IntegracaoToledoConfig>(Configuration.GetSection(nameof(IntegracaoToledoConfig)));
            services.Configure<BalancaFerroviariaGenericConfig>(Configuration.GetSection(nameof(BalancaFerroviariaGenericConfig)));


            // Create the container builder.
            var builder = new ContainerBuilder();
            builder.Populate(services);

            IOC.Builder = builder;
            ApplicationContainer = IOC.Start();

            //var _permissaoAcessoRepository = IOC.Container.Resolve<IPermissaoAcessoRepository>();

            //var acessos = _permissaoAcessoRepository.GetAll();
            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            loggerFactory.AddLog4Net();

            //app.ConfigureExceptionHandler(loggerFactory);
            app.ConfigureCustomExceptionMiddleware();
            app.UseCors("AllowAll");
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
