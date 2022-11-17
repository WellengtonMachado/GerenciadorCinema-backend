using GerenciadorCimena.Dominio.ModuloSessoes;
using System;

namespace GerenciadorCinema.Webapi.ViewModels.ModuloSessao
{
    public class FormsSessaoViewModel
    {
        public Guid Id { get; set; }

        public DateTime Data { get; set; }

        public TimeSpan HorarioInicio { get; set; }

        public TimeSpan HorarioFim { get; set; }

        public decimal ValorIngresso { get; set; }

        public TipoAnimacaoEnum Animacao { get; set; }

        public TipoAudioEnum Audio { get; set; }

        public Guid FilmeId { get; set; }

        public Guid SalaId { get; set; }
    }
}