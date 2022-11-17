using GerenciadorCimena.Dominio.Compartilhado;
using GerenciadorCimena.Dominio.ModuloFilmes;
using GerenciadorCimena.Dominio.ModuloSalas;
using GerenciadorCimena.Dominio.ModuloSessoes;
using GerenciadorCinema.Infra.Orm.Compartilhado;
using GerenciadorCinema.Infra.Orm.ModuloFilme;
using GerenciadorCinema.Infra.Orm.ModuloSala;
using GerenciadorCinema.Infra.Orm.ModuloSessao;
using GerenciadorCinema.Servico.ModuloFilme;
using GerenciadorCinema.Servico.ModuloSala;
using GerenciadorCinema.Servico.ModuloSessao;
using GerenciamentoCinema.Infra.Configs;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciadorCinema.Webapi.Config
{
    public static class DependencyInjectionConfig
    {
        public static void ConfigurarInjecaoDependencia(this IServiceCollection services)
        {
            services.AddSingleton((x) => new ConfiguracaoAplicacaoGerenciamentoCinema().ConnectionStrings);

            services.AddScoped<GerenciadorCinemaDbContext>();

            services.AddScoped<IContextoPersistencia, GerenciadorCinemaDbContext>();

            services.AddScoped<IRepositorioSala, RepositorioSalaOrm>();
            services.AddTransient<ServicoSala>();

            services.AddScoped<IRepositorioFilme, RepositorioFilmeOrm>();
            services.AddTransient<ServicoFilme>();

            services.AddScoped<IRepositorioSessao, RepositorioSessaoOrm>();
            services.AddTransient<ServicoSessao>();          

        }
    }
}