using System;

namespace GerenciadorCinema.Webapi.ViewModels.ModuloSala
{
    public class ListarSalaViewModel
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string QuantidadeAssentos { get; set; }
    }
}
