using GerenciadorCimena.Dominio.Compartilhado;
using GerenciadorCimena.Dominio.ModuloFilmes;
using GerenciadorCinema.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorCinema.Infra.Orm.ModuloFilme
{
    public class RepositorioFilmeOrm : RepositorioBase<Filme>, IRepositorioFilme
    {
        public RepositorioFilmeOrm(IContextoPersistencia contextoPersistencia) : base(contextoPersistencia)
        {
        }

        public Filme SelecionarFilmePorNome(string titulo)
        {
            return registros.SingleOrDefault(x => x.Titulo == titulo);  
        }

        public override Filme SelecionarPorId(Guid id)
        {
            return registros
                .Include(x => x.Sessoes)
                .SingleOrDefault(x => x.Id == id);
        }

       
    }
}
