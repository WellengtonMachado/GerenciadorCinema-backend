using AutoMapper;
using GerenciadorCimena.Dominio.ModuloSalas;
using GerenciadorCinema.Webapi.ViewModels.ModuloSala;

namespace GerenciadorCinema.Webapi.Config.AutoMapperConfig
{
    public class SalaProfile : Profile
    {
        public SalaProfile()
        {
            CreateMap<FormsSalaViewModel, Sala>()
                .ForMember(destino => destino.QuantidadeAssentos, opt => opt.MapFrom(origem => origem.QuantidadeAssentos))

                .ForMember(destino => destino.UsuarioId, opt => opt.MapFrom<UsuarioResolver>())

                .ForMember(destino => destino.Id, opt => opt.Ignore());

            CreateMap<Sala, ListarSalaViewModel>()
                .ForMember(destino => destino.QuantidadeAssentos, opt => opt.MapFrom(origem => origem.QuantidadeAssentos));

            CreateMap<Sala, VisualizarSalaViewModel>()
                .ForMember(destino => destino.QuantidadeAssentos, opt => opt.MapFrom(origem => origem.QuantidadeAssentos))

                .ForMember(destino => destino.Sessoes, opt => opt.MapFrom(origem => origem.Sessoes));

            CreateMap<Sala, FormsSalaViewModel>()
                .ForMember(destino => destino.QuantidadeAssentos, opt => opt.MapFrom(origem => origem.QuantidadeAssentos));

        }
    }
}

