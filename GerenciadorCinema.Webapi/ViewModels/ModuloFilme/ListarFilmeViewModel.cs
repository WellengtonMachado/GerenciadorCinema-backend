using System;

namespace GerenciadorCinema.Webapi.ViewModels.ModuloFilme
{
    public class ListarFilmeViewModel
    {
        public Guid Id { get; set; }

        public string Imagem { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public string Duracao { get; set; }

    }
}
