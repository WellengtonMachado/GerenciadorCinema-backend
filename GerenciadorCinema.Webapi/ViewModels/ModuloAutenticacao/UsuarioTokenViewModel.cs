using System;

namespace GerenciadorCinema.Webapi.ViewModels.ModuloAutenticacao
{
    public class UsuarioTokenViewModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
    }
}
