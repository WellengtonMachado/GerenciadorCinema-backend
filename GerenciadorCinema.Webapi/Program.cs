using GerenciadorCinema.Infra.Orm.Compartilhado;
using GerenciamentoCinema.Infra.Configs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

namespace GerenciadorCinema.Webapi
{
    public class Program
    {
        public static void Main(string[] args)
        {           

            try
            {
                var app = CreateHostBuilder(args).Build();

                using (var scope = app.Services.CreateScope())
                {       
                    var services = scope.ServiceProvider;

                    var db = services.GetRequiredService<GerenciadorCinemaDbContext>();

                    Log.Logger.Information("Atualizando a banco de dados do e-Agenda...");

                    var migracaoRealizada = MigradorBancoDadosGerenciadorCinema.AtualizarBancoDados(db);

                    if (migracaoRealizada)
                        Log.Logger.Information("Banco de dados atualizado");
                    else
                        Log.Logger.Information("Nenhuma migração pendente");
                }

                Log.Logger.Information("Iniciando o servidor da aplicação e-Agenda...");

                app.Run();

            }
            catch (Exception exc)
            {
                Log.Logger.Fatal(exc, "O servidor do Gerenciador de Cinema parou inesperadamente.");
                throw;
            }
        }



        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }


}

