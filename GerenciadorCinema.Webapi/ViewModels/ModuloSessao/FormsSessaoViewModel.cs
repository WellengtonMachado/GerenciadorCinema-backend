using GerenciadorCimena.Dominio.ModuloSessoes;
using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorCinema.Webapi.ViewModels.ModuloSessao
{
    public class FormsSessaoViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        public DateTime Data { get; set; }


        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        public TimeSpan HorarioInicio { get; set; }

       
        public TimeSpan HorarioFim { get; set; }


        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        public decimal ValorIngresso { get; set; }


        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        public TipoAnimacaoEnum Animacao { get; set; }


        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        public TipoAudioEnum Audio { get; set; }


        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        public Guid FilmeId { get; set; }


        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        public Guid SalaId { get; set; }
    }
}