using GerenciadorCimena.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorCimena.Dominio.ModuloSessoes
{
    public interface IRepositorioSessao : IRepositorio<Sessao>
    {

        List<Sessao> SelecionarSessaoPorData(DateTime data, Guid usuarioId = new Guid());
    }
}
