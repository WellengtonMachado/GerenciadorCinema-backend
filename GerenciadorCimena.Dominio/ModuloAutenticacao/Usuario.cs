using Microsoft.AspNetCore.Identity;
using System;


namespace GerenciadorCimena.Dominio.ModuloAutenticacao
{
    public class Usuario : IdentityUser<Guid>
    {
        public string Nome { get; set; }
    }
}
