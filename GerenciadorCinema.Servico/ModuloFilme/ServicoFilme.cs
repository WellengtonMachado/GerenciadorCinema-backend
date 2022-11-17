using FluentResults;
using GerenciadorCimena.Dominio.Compartilhado;
using GerenciadorCimena.Dominio.ModuloFilmes;
using GerenciadorCinema.Servico.Compartilhado;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorCinema.Servico.ModuloFilme
{
    public class ServicoFilme : ServicoBase<Filme, ValidadorFilme>
    {
        private IRepositorioFilme repositorioFilme;
        private IContextoPersistencia contextoPersistencia;

        public ServicoFilme(IRepositorioFilme repositorioFilme, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioFilme = repositorioFilme;
            this.contextoPersistencia = contextoPersistencia;
        }


        public Result<Filme> Inserir(Filme filme)
        {
            Log.Logger.Debug("Tentando inserir filme. {@f}", filme);

            Result resultado = Validar(filme);

            if (resultado.IsFailed)
                return Result.Fail(resultado.Errors);

            try
            {
                repositorioFilme.Inserir(filme);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Filme {FilmeId} inserido com sucesso", filme.Id);

                return Result.Ok(filme);
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha no sistema ao tentar inserir o Filme";

                Log.Logger.Error(ex, msgErro + " {FilmeId} ", filme.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Filme> Editar(Filme filme)
        {
            Log.Logger.Debug("Tentando editar filme. {@f}", filme);

            var resultado = Validar(filme);

            if (resultado.IsFailed)
                return Result.Fail(resultado.Errors);

            try
            {
                repositorioFilme.Editar(filme);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Filme {FilmeId} editado com sucesso", filme.Id);
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha no sistema ao tentar editar o Filme";

                Log.Logger.Error(ex, msgErro + " {FilmeId}", filme.Id);

                return Result.Fail(msgErro);
            }

            return Result.Ok(filme);
        }

        public Result Excluir(Guid id)
        {
            var filmeResult = SelecionarPorId(id);

            if (filmeResult.IsSuccess)
                return Excluir(filmeResult.Value);

            return Result.Fail(filmeResult.Errors);
        }

        public Result Excluir(Filme filme)
        {
            Log.Logger.Debug("Tentando excluir filme... {@f}", filme);

            try
            {
                repositorioFilme.Excluir(filme);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Filme {FilmeId} editado com sucesso", filme.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha no sistema ao tentar excluir o filme";

                Log.Logger.Error(ex, msgErro + " {FilmeId}", filme.Id);

                return Result.Fail(msgErro);
            }
        }


        public Result<List<Filme>> SelecionarTodos(Guid usuarioId = new Guid())
        {
            Log.Logger.Debug("Tentando selecionar os filmes...");

            try
            {
                var filmes = repositorioFilme.SelecionarTodos(usuarioId);

                Log.Logger.Information("Filmes selecionados com sucesso");

                return Result.Ok(filmes);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os Filmes";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Filme> SelecionarPorId(Guid id)
        {
            Log.Logger.Debug("Tentando selecionar filme {FilmeId}...", id);

            try
            {
                var filme = repositorioFilme.SelecionarPorId(id);

                if (filme == null)
                {
                    Log.Logger.Warning("Filme {FilmeId} não encontrado", id);

                    return Result.Fail("Filme não encontrado");
                }

                Log.Logger.Information("Filme {FilmeId} selecionado com sucesso", id);

                return Result.Ok(filme);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o Filme";

                Log.Logger.Error(ex, msgErro + " {FilmeId}", id);

                return Result.Fail(msgErro);
            }
        }


    }
}
