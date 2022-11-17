using FluentResults;
using GerenciadorCimena.Dominio.Compartilhado;
using GerenciadorCimena.Dominio.ModuloSessoes;
using GerenciadorCinema.Servico.Compartilhado;
using Serilog;
using System;
using System.Collections.Generic;


namespace GerenciadorCinema.Servico.ModuloSessao
{
    public class ServicoSessao : ServicoBase<Sessao, ValidadorSessao>
    {
        private IRepositorioSessao repositorioSessao;
        private IContextoPersistencia contextoPersistencia;

        public ServicoSessao(IRepositorioSessao repositorioSessao, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioSessao = repositorioSessao;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result<Sessao> Inserir(Sessao sessao)
        {
            Log.Logger.Debug("Tentando inserir sessão. {@s}", sessao);

            Result resultado = Validar(sessao);

            if (resultado.IsFailed)
                return Result.Fail(resultado.Errors);

            try
            {
                repositorioSessao.Inserir(sessao);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Sessão {SessaoId} inserida com sucesso", sessao.Id);

                return Result.Ok(sessao);
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha no sistema ao tentar inserir a Sessão";

                Log.Logger.Error(ex, msgErro + " {SessaoId} ", sessao.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Sessao> Editar(Sessao sessao)
        {
            Log.Logger.Debug("Tentando editar Sessão... {@s}", sessao);

            var resultado = Validar(sessao);

            if (resultado.IsFailed)
                return Result.Fail(resultado.Errors);

            try
            {
                repositorioSessao.Editar(sessao);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Sessão {SessaoId} editada com sucesso", sessao.Id);
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha no sistema ao tentar editar a Sessão";

                Log.Logger.Error(ex, msgErro + " {SessaoId}", sessao.Id);

                return Result.Fail(msgErro);
            }

            return Result.Ok(sessao);
        }


        public Result Excluir(Sessao sessao)
        {
            Log.Logger.Debug("Tentando excluir Sessão... {@s}", sessao);

            try
            {
                repositorioSessao.Excluir(sessao);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Sessão {SessaoId} editada com sucesso", sessao.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha no sistema ao tentar excluir a Sessão";

                Log.Logger.Error(ex, msgErro + " {SessaoId}", sessao.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Guid id)
        {
            var sessaoResult = SelecionarPorId(id);

            if (sessaoResult.IsSuccess)
                return Excluir(sessaoResult.Value);

            return Result.Fail(sessaoResult.Errors);
        }


        public Result<List<Sessao>> SelecionarTodos(Guid usuarioId = new Guid())
        {
            Log.Logger.Debug("Tentando selecionar Sessões...");

            try
            {
                var sessoes = repositorioSessao.SelecionarTodos(usuarioId);

                Log.Logger.Information("Sessões selecionadas com sucesso");

                return Result.Ok(sessoes);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todas as Sessões";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Sessao> SelecionarPorId(Guid id)
        {
            Log.Logger.Debug("Tentando selecionar Sessão {SessaoId}...", id);

            try
            {
                var sessao = repositorioSessao.SelecionarPorId(id);

                if (sessao == null)
                {
                    Log.Logger.Warning("Sessão {SessaoId} não encontrada", id);

                    return Result.Fail("Sessão não encontrada");
                }

                Log.Logger.Information("Sessão {SessaoId} selecionado com sucesso", id);

                return Result.Ok(sessao);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar a Sessão";

                Log.Logger.Error(ex, msgErro + " {SessaoId}", id);

                return Result.Fail(msgErro);
            }
        }


        public Result <List<Sessao>>  SelecionarSessaoPorData(DateTime data, Guid usuarioId = new Guid())
        {
            return repositorioSessao.SelecionarSessaoPorData(data);

        }

    }
}
