﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorCimena.Dominio.Compartilhado
{
    public interface IRepositorio<T> where T : EntidadeBase<T>
    {
        void Inserir(T novoRegistro);

        void Editar(T registro);

        void Excluir(T registro);

        List<T> SelecionarTodos();

        T SelecionarPorId(Guid numero);

        
    }
}
