using System;

namespace GerenciadorCinema.Webapi.ViewModels.ModuloSessao
{
    public class ListarSessaoViewModel
    {
        public Guid Id { get; set; }

        public string Data { get; set; }

        public string HorarioInicio { get; set; }

        public string HorarioFim { get; set; }

        public decimal ValorIngresso { get; set; }

        public string Animacao { get; set; }

        public string Audio { get; set; }

        public string NomeFilme { get; set; }

        public string NomeSala { get; set; }
    }
}
