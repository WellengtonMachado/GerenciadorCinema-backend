using AutoMapper;
using GerenciadorCimena.Dominio.ModuloFilmes;
using GerenciadorCimena.Dominio.ModuloSessoes;
using GerenciadorCinema.Webapi.ViewModels.ModuloSessao;

namespace GerenciadorCinema.Webapi.Config.AutoMapperConfig
{
    public class ConfigurarDuracaoFilme : IMappingAction<FormsSessaoViewModel, Sessao>
    {
        public IRepositorioFilme repositorioFilme;

        public ConfigurarDuracaoFilme(IRepositorioFilme repositorioFilme)
        {
            this.repositorioFilme = repositorioFilme;
        }

        public void Process(FormsSessaoViewModel sessaoVM, Sessao sessao, ResolutionContext context)
        {
            sessao.Filme = repositorioFilme.SelecionarPorId(sessaoVM.FilmeId);

            sessao.HorarioFim = sessao.HorarioInicio + sessao.Filme.Duracao;


        }
    }
}