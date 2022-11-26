using GerenciadorCimena.Dominio.Compartilhado;
using GerenciadorCimena.Dominio.ModuloSalas;
using GerenciadorCinema.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace GerenciadorCinema.Infra.Orm.ModuloSala
{
    public class RepositorioSalaOrm : RepositorioBase<Sala>, IRepositorioSala
    {
        public RepositorioSalaOrm(IContextoPersistencia contextoPersistencia) : base(contextoPersistencia)
        {
        }

        public override Sala SelecionarPorId(Guid id)
        {
            return registros
                .Include(x => x.Sessoes)
                .SingleOrDefault(x => x.Id == id);
        }
    }
}
