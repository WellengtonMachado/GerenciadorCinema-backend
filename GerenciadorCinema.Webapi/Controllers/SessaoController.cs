using AutoMapper;
using GerenciadorCimena.Dominio.ModuloSessoes;
using GerenciadorCinema.Servico.ModuloSessao;
using GerenciadorCinema.Webapi.Controllers.Compartilhado;
using GerenciadorCinema.Webapi.ViewModels.ModuloSessao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GerenciadorCinema.Webapi.Controllers
{
    [Route("api/Sessoes")]
    [ApiController]
    [Authorize]
    public class SessaoController : GerenciadorCinemaControllerBase
    {
        private readonly ServicoSessao servicoSessao;
        private readonly IMapper mapeadorSessoes;

        public SessaoController(ServicoSessao servicoSessao, IMapper mapeadorSessoes)
        {
            this.servicoSessao = servicoSessao;
            this.mapeadorSessoes = mapeadorSessoes;
        }

        [HttpGet]
        public ActionResult<List<ListarSessaoViewModel>> SelecionarTodos()
        {
            var sessaoResult = servicoSessao.SelecionarTodos(UsuarioLogado.Id);

            if (sessaoResult.IsFailed)
                return InternalError(sessaoResult);

            return Ok(new
            {
                sucesso = true,
                dados = mapeadorSessoes.Map<List<ListarSessaoViewModel>>(sessaoResult.Value)
            });
        }

        [HttpGet, Route("passados/{dataAtual:datetime}")]
        public ActionResult<List<ListarSessaoViewModel>> SelecionarSessaoPorData(DateTime data)
        {
            var sessaoResult = servicoSessao.SelecionarSessaoPorData(data, UsuarioLogado.Id);

            if (sessaoResult.IsFailed)
                return InternalError(sessaoResult);

            return Ok(new
            {
                sucesso = true,
                dados = mapeadorSessoes.Map<List<ListarSessaoViewModel>>(sessaoResult.Value)
            });
        }

        [HttpGet("visualizacao-completa/{id:guid}")]
        public ActionResult<VisualizarSessaoViewModel> SelecionarSessaoCompletoPorId(Guid id)
        {
            var sessaoResult = servicoSessao.SelecionarPorId(id);

            if (sessaoResult.IsFailed && RegistroNaoEncontrado(sessaoResult))
                return NotFound(sessaoResult);

            if (sessaoResult.IsFailed)
                return InternalError(sessaoResult);

            return Ok(new
            {
                sucesso = true,
                dados = mapeadorSessoes.Map<VisualizarSessaoViewModel>(sessaoResult.Value)
            });
        }

        [HttpGet("{id:guid}")]
        public ActionResult<FormsSessaoViewModel> SelecionarSessaoPorId(Guid id)
        {
            var sessaoResult = servicoSessao.SelecionarPorId(id);

            if (sessaoResult.IsFailed && RegistroNaoEncontrado(sessaoResult))
                return NotFound(sessaoResult);

            if (sessaoResult.IsFailed)
                return InternalError(sessaoResult);

            return Ok(new
            {
                sucesso = true,
                dados = mapeadorSessoes.Map<FormsSessaoViewModel>(sessaoResult.Value)
            });
        }

        [HttpPost]
        public ActionResult<FormsSessaoViewModel> Inserir(FormsSessaoViewModel sessaoVM)
        {
            var sessao = mapeadorSessoes.Map<Sessao>(sessaoVM);

            var sessaoResult = servicoSessao.Inserir(sessao);

            if (sessaoResult.IsFailed)
                return InternalError(sessaoResult);

            return Ok(new
            {
                sucesso = true,
                dados = sessaoVM
            });
        }

        [HttpPut("{id:guid}")]
        public ActionResult<FormsSessaoViewModel> Editar(Guid id, FormsSessaoViewModel sessaoVM)
        {
            var sessaoResult = servicoSessao.SelecionarPorId(id);

            if (sessaoResult.IsFailed && RegistroNaoEncontrado(sessaoResult))
                return NotFound(sessaoResult);

            var sessao = mapeadorSessoes.Map(sessaoVM, sessaoResult.Value);

            sessaoResult = servicoSessao.Editar(sessao);

            if (sessaoResult.IsFailed)
                return InternalError(sessaoResult);

            return Ok(new
            {
                sucesso = true,
                dados = sessaoVM
            });
        }

        [HttpDelete("{id:guid}")]
        public ActionResult Excluir(Guid id)
        {
            var sessaoResult = servicoSessao.Excluir(id);

            if (sessaoResult.IsFailed && RegistroNaoEncontrado<Sessao>(sessaoResult))
                return NotFound<Sessao>(sessaoResult);

            if (sessaoResult.IsFailed)
                return InternalError<Sessao>(sessaoResult);

            return NoContent();
        }

    }
}
