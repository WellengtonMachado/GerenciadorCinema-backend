using System;

namespace GerenciadorCinema.Webapi.ViewModels.ModuloAutenticacao
{
    public class TokenViewModel
    {
        public string Chave { get; set; }

        public UsuarioTokenViewModel UsuarioToken { get; set; }

        public DateTime DataExpiracacao { get; set; }
    }
}
