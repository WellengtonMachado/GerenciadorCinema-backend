using GerenciamentoCinema.Infra.Configs;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace GerenciadorCinema.Infra.Orm.Compartilhado
{
    public static class MigradorBancoDadosGerenciadorCinema
    {
        public static bool AtualizarBancoDados(DbContext db)
        {
            var qtdMigracoesPendentes = db.Database.GetPendingMigrations().Count();

            if (qtdMigracoesPendentes == 0)
                return false;

            db.Database.Migrate();

            return true;
        }

    }
}
