using FluentResults;
using FluentValidation.Results;
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

                Log.Logger.Information("Filme {FilmeId} excluido com sucesso", filme.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha no sistema ao tentar excluir o Filme";

                if ((bool)(ex.InnerException?.Message?.StartsWith("Cannot insert the value NULL into column 'FilmeId'")))
                {
                    msgErro = "Não foi possivel remover este filme, pois ele está vinculado a uma sessão";
                }

                Log.Logger.Error(ex, msgErro + " {FilmeId}", filme.Id);

                return Result.Fail(msgErro);
            }
        }


        public Result<List<Filme>> SelecionarTodos()
        {
            Log.Logger.Debug("Tentando selecionar os filmes...");

            try
            {
                var filmes = repositorioFilme.SelecionarTodos();

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


        protected override Result Validar(Filme arg)
        {
            var validador = new ValidadorFilme();

            var resultadoValidacao = validador.Validate(arg);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
                erros.Add(new Error(item.ErrorMessage));

            if (NomeFilmeDuplicado(arg))
                erros.Add(new Error("Título do filme duplicado"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }


        private bool NomeFilmeDuplicado(Filme arg)
        {
            var filmeEncontrado = repositorioFilme.SelecionarFilmePorNome(arg.Titulo);

            return filmeEncontrado != null &&
                   filmeEncontrado.Titulo == arg.Titulo &&
                   filmeEncontrado.Id != arg.Id;
        }



    }
}
