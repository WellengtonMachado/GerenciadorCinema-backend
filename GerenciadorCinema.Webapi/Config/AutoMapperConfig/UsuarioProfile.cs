using AutoMapper;
using GerenciadorCimena.Dominio.ModuloAutenticacao;
using GerenciadorCinema.Webapi.ViewModels.ModuloAutenticacao;

namespace GerenciadorCinema.Webapi.Config.AutoMapperConfig
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<RegistrarUsuarioViewModel, Usuario>()
                .ForMember(destino => destino.EmailConfirmed, opt => opt.MapFrom(origem => true))
                .ForMember(destino => destino.UserName, opt => opt.MapFrom(origem => origem.Email));
        }
    }
}
