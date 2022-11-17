using AutoMapper;
using GerenciadorCimena.Dominio.ModuloSessoes;
using GerenciadorCinema.Webapi.ViewModels.ModuloSessao;

namespace GerenciadorCinema.Webapi.Config.AutoMapperConfig
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<FormsSessaoViewModel, Sessao>()
                .ForMember(destino => destino.UsuarioId, opt => opt.MapFrom<UsuarioResolver>())

                 .ForMember(destino => destino.Id, opt => opt.Ignore());


            CreateMap<Sessao, ListarSessaoViewModel>()
                .ForMember(d => d.Data, opt => opt.MapFrom(o => o.Data.ToString("dd/MM/yyyy")))
                .ForMember(d => d.HorarioInicio, opt => opt.MapFrom(o => o.HorarioInicio.ToString(@"hh\:mm\:ss")))
                .ForMember(d => d.HorarioFim, opt => opt.MapFrom(o => o.HorarioFim.ToString(@"hh\:mm\:ss")))
                .ForMember(d => d.ValorIngresso, opt => opt.MapFrom(o => o.ValorIngresso))
                .ForMember(d => d.Animacao, opt => opt.MapFrom(o => o.Animacao))
                .ForMember(d => d.Audio, opt => opt.MapFrom(o => o.Audio))
                .ForMember(d => d.NomeFilme, opt => opt.MapFrom(o => o.Filme.Titulo))
                .ForMember(d => d.NomeSala, opt => opt.MapFrom(o => o.Sala.Nome));


            CreateMap<Sessao, VisualizarSessaoViewModel>();


            CreateMap<Sessao, FormsSessaoViewModel>();



        }
    }
}
