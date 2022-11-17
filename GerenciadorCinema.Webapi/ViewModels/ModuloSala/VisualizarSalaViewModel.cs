using GerenciadorCinema.Webapi.ViewModels.ModuloSessao;
using System;
using System.Collections.Generic;

namespace GerenciadorCinema.Webapi.ViewModels.ModuloSala
{
    public class VisualizarSalaViewModel
    {
        public VisualizarSalaViewModel() 
        { 
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }

        public string QuantidadeAssentos { get; set; }

        public List<ListarSessaoViewModel> Sessoes { get; set; }

    }
}
