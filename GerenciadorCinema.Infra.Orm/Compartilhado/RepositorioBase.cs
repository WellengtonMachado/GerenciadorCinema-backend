using GerenciadorCimena.Dominio.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorCinema.Infra.Orm.Compartilhado
{
    public abstract class RepositorioBase<TEntity> where TEntity : EntidadeBase<TEntity>
    {
        protected DbSet<TEntity> registros;
        private readonly GerenciadorCinemaDbContext dbContext;

        public RepositorioBase(IContextoPersistencia contextoPersistencia)
        {
            dbContext = (GerenciadorCinemaDbContext)contextoPersistencia;
            registros = dbContext.Set<TEntity>();
        }

        public virtual void Inserir(TEntity novoRegistro)
        {
            registros.Add(novoRegistro);
        }

        public virtual void Editar(TEntity registro)
        {
            registros.Update(registro);
        }

        public virtual void Excluir(TEntity registro)
        {
            registros.Remove(registro);
        }

        public virtual TEntity SelecionarPorId(Guid id)
        {
            return registros
                .SingleOrDefault(x => x.Id == id);
        }

        public virtual List<TEntity> SelecionarTodos(Guid usuarioId = new Guid())
        {
            return registros
                .Where(x => x.UsuarioId.Equals(usuarioId))
                .ToList();
        }
    }
}
