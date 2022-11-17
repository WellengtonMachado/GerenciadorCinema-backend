using AutoMapper;
using GerenciadorCimena.Dominio.ModuloSalas;
using GerenciadorCinema.Servico.ModuloSala;
using GerenciadorCinema.Webapi.Controllers.Compartilhado;
using GerenciadorCinema.Webapi.ViewModels.ModuloSala;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GerenciadorCinema.Webapi.Controllers
{
    [Route("api/salas")]
    [ApiController]
    [Authorize]
    public class SalaController : GerenciadorCinemaControllerBase
    {
        private readonly ServicoSala servicoSala;
        private readonly IMapper mapeadorSalas;

        public SalaController(ServicoSala servicoSala, IMapper mapeadorSalas)
        {
            this.servicoSala = servicoSala;
            this.mapeadorSalas = mapeadorSalas;
        }

        [HttpGet]
        public ActionResult<List<ListarSalaViewModel>> SelecionarTodos()
        {
            var salaResult = servicoSala.SelecionarTodos(UsuarioLogado.Id);

            if (salaResult.IsFailed)
                return InternalError(salaResult);

            return Ok(new
            {
                sucesso = true,
                dados = mapeadorSalas.Map<List<ListarSalaViewModel>>(salaResult.Value)
            });
        }


        [HttpGet("visualizacao-completa/{id:guid}")]
        public ActionResult<VisualizarSalaViewModel> SelecionarSalaCompletaPorId(Guid id)
        {
            var salaResult = servicoSala.SelecionarPorId(id);

            if (salaResult.IsFailed && RegistroNaoEncontrado(salaResult))
                return NotFound(salaResult);

            if (salaResult.IsFailed)
                return InternalError(salaResult);

            return Ok(new
            {
                sucesso = true,
                dados = mapeadorSalas.Map<VisualizarSalaViewModel>(salaResult.Value)
            });
        }


        [HttpGet("{id:guid}")]
        public ActionResult<FormsSalaViewModel> SelecionarSalaPorId(Guid id)
        {
            var salaResult = servicoSala.SelecionarPorId(id);

            if (salaResult.IsFailed && RegistroNaoEncontrado(salaResult))
                return NotFound(salaResult);

            if (salaResult.IsFailed)
                return InternalError(salaResult);

            return Ok(new
            {
                sucesso = true,
                dados = mapeadorSalas.Map<FormsSalaViewModel>(salaResult.Value)
            });
        }


        [HttpPost]
        public ActionResult<FormsSalaViewModel> Inserir(FormsSalaViewModel salaVM)
        {
            var sala = mapeadorSalas.Map<Sala>(salaVM);

            var salaResult = servicoSala.Inserir(sala);

            if (salaResult.IsFailed)
                return InternalError(salaResult);

            return Ok(new
            {
                sucesso = true,
                dados = salaVM
            });
        }


        [HttpPut("{id:guid}")]
        public ActionResult<FormsSalaViewModel> Editar(Guid id, FormsSalaViewModel salaVM)
        {
            var SalaResult = servicoSala.SelecionarPorId(id);

            if (SalaResult.IsFailed && RegistroNaoEncontrado(SalaResult))
                return NotFound(SalaResult);

            var sala = mapeadorSalas.Map(salaVM, SalaResult.Value);

            SalaResult = servicoSala.Editar(sala);

            if (SalaResult.IsFailed)
                return InternalError(SalaResult);

            return Ok(new
            {
                sucesso = true,
                dados = salaVM
            });
        }


        [HttpDelete("{id:guid}")]
        public ActionResult Excluir(Guid id)
        {
            var salaResult = servicoSala.Excluir(id);

            if (salaResult.IsFailed && RegistroNaoEncontrado<Sala>(salaResult))
                return NotFound<Sala>(salaResult);

            if (salaResult.IsFailed)
                return InternalError<Sala>(salaResult);

            return NoContent();
        }

    }
}
