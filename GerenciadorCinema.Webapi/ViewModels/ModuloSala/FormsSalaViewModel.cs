using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorCinema.Webapi.ViewModels.ModuloSala
{
    public class FormsSalaViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        public string QuantidadeAssentos { get; set; }
    }
}
