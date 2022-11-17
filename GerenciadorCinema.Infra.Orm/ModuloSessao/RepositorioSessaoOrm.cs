using GerenciadorCimena.Dominio.Compartilhado;
using GerenciadorCimena.Dominio.ModuloSessoes;
using GerenciadorCinema.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorCinema.Infra.Orm.ModuloSessao
{
    public class RepositorioSessaoOrm : RepositorioBase<Sessao>, IRepositorioSessao
    {
        public RepositorioSessaoOrm(IContextoPersistencia contextoPersistencia) : base(contextoPersistencia)
        {
        }

        public override Sessao SelecionarPorId(Guid id)
        {
            return registros
                .Include(x => x.Filme)
                .Include(x => x.Sala)
                .SingleOrDefault(x => x.Id == id);
        }

        public override List<Sessao> SelecionarTodos(Guid usuarioId = new Guid())
        {
            return registros
                .Include(x => x.Filme)
                .Include(x => x.Sala)
                .Where(x => x.UsuarioId.Equals(usuarioId))
                .ToList();
        }


        // verificar 
        public List<Sessao> SelecionarSessaoPorData(DateTime data, Guid usuarioId = new Guid())
        {
            return registros
                .Include(x => x.Filme)
                .Include(x => x.Sala)
                .Where(x => x.Data > data)
                .Where(x => x.UsuarioId.Equals(usuarioId))
                .ToList();
        }
    }
}
