using GerenciadorCimena.Dominio.ModuloAutenticacao;
using System;
using Taikandi;

namespace GerenciadorCimena.Dominio.Compartilhado
{
    public abstract class EntidadeBase<T> 
    {
        public Guid Id { get; set; }

        

        public EntidadeBase()
        {
            Id = SequentialGuid.NewGuid();
        }

        public abstract void Atualizar(T registro);
    }
}