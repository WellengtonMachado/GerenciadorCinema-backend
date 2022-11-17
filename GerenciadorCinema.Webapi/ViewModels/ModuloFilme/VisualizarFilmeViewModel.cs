using GerenciadorCinema.Webapi.ViewModels.ModuloSessao;
using System;
using System.Collections.Generic;

namespace GerenciadorCinema.Webapi.ViewModels.ModuloFilme
{
    public class VisualizarFilmeViewModel
    {
        public VisualizarFilmeViewModel()
        {
        }

        public Guid Id { get; set; }

        public byte[] Imagem { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public TimeSpan Duracao { get; set; }

        public List<ListarSessaoViewModel> Sessoes { get; set; }

    }
}
