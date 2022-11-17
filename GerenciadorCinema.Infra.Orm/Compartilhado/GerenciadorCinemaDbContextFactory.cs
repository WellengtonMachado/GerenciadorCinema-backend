
using GerenciamentoCinema.Infra.Configs;
using Microsoft.EntityFrameworkCore.Design;


namespace GerenciadorCinema.Infra.Orm.Compartilhado
{
    public class GerenciadorCinemaDbContextFactory : IDesignTimeDbContextFactory<GerenciadorCinemaDbContext>
    {
        public GerenciadorCinemaDbContext CreateDbContext(string[] args)
        {
            var config = new ConfiguracaoAplicacaoGerenciamentoCinema();

            return new GerenciadorCinemaDbContext(config.ConnectionStrings);
        }

    }
}
