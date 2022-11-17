using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorCinema.Webapi.ViewModels.ModuloFilme
{
    public class FormsFilmeViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        public byte[] Imagem { get; set; }

        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        public TimeSpan Duracao { get; set; }
    }
}
