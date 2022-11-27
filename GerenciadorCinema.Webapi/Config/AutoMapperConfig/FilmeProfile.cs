using AutoMapper;
using GerenciadorCimena.Dominio.ModuloFilmes;
using GerenciadorCinema.Webapi.ViewModels.ModuloFilme;

namespace GerenciadorCinema.Webapi.Config.AutoMapperConfig
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            //Converter de ViewModel para Entidade
            CreateMap<FormsFilmeViewModel, Filme>()                     
                               
                .ForMember(destino => destino.Id, opt => opt.Ignore());


            //Converter de Entidade para ViewModel
            CreateMap<Filme, ListarFilmeViewModel>()               

                .ForMember(destino => destino.Duracao, opt => opt.MapFrom(origem => origem.Duracao.ToString(@"hh\:mm\:ss")));


            CreateMap<Filme, VisualizarFilmeViewModel>()
                .ForMember(destino => destino.Sessoes, opt => opt.MapFrom(origem => origem.Sessoes));



            CreateMap<Filme, FormsFilmeViewModel>();
               

        }
    }
}
