using GerenciadorCimena.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorCimena.Dominio.ModuloFilmes
{
    public interface IRepositorioFilme : IRepositorio<Filme>
    {
        Filme SelecionarFilmePorNome(string titulo);
    }
}
