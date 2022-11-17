using GerenciadorCimena.Dominio.ModuloSessoes;
using GerenciadorCinema.Webapi.ViewModels.ModuloFilme;
using GerenciadorCinema.Webapi.ViewModels.ModuloSala;
using System;

namespace GerenciadorCinema.Webapi.ViewModels.ModuloSessao
{
    public class VisualizarSessaoViewModel
    {
        public Guid Id { get; set; }

        public DateTime Data { get; set; }

        public TimeSpan HorarioInicio { get; set; }

        public TimeSpan HorarioFim { get; set; }

        public decimal ValorIngresso { get; set; }

        public TipoAnimacaoEnum Animacao { get; set; }

        public TipoAudioEnum Audio { get; set; }


        public ListarFilmeViewModel Filme { get; set; }

        public ListarSalaViewModel Sala { get; set; }
    }
}
