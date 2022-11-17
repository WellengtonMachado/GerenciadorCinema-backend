using GerenciadorCinema.Infra.Logging;
using GerenciadorCinema.Webapi.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorCinema.Webapi
{
    public class Startup
    {
        private IConfiguracaoLogsGerenciadorCinema configuracaoLogsGerenciadorCinema;

        public Startup(IWebHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("ConfiguracaoAplicacao.json", true, true)
                .AddJsonFile($"ConfiguracaoAplicacao.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();

            if (hostEnvironment.IsDevelopment())
            {
                configuracaoLogsGerenciadorCinema = new ConfiguracaoLogsLocal(Configuration);
            }
            else
            {
                configuracaoLogsGerenciadorCinema = new ConfiguracaoLogsAzure();
            }

            configuracaoLogsGerenciadorCinema.ConfigurarEscritaLogs();
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(config =>
            {
                config.SuppressModelStateInvalidFilter = true;
            });

            services.AddHttpContextAccessor();

            services.AddAutoMapper(typeof(Startup));

            services.ConfigurarInjecaoDependencia();

            services.ConfigurarAutenticacao();

            services.ConfigurarFiltros();

            services.ConfigurarSwagger();

            services.ConfigurarJwt();

            services.AddCors(options =>
            {
                options.AddPolicy("Desenvolvimento",
                    services =>
                        services.WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "eAgenda.Webapi v1"));
            }


            app.UseCors("Desenvolvimento");

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
