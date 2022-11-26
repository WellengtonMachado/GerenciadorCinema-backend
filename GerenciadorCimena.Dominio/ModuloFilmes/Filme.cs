using GerenciadorCimena.Dominio.Compartilhado;
using GerenciadorCimena.Dominio.ModuloAutenticacao;
using GerenciadorCimena.Dominio.ModuloSessoes;
using System;
using System.Collections.Generic;


namespace GerenciadorCimena.Dominio.ModuloFilmes
{
    public class Filme : EntidadeBase<Filme>
    {        

        public string Imagem { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public TimeSpan Duracao { get; set; }

        public List<Sessao> Sessoes { get; set; }        

        

        public Filme()
        {
        }

        public Filme(string imagem, string titulo, string descricao, TimeSpan duracao)
        {
            Imagem = imagem;
            Titulo = titulo;
            Descricao = descricao;
            Duracao = duracao;
        }

        public override void Atualizar(Filme registro)
        {
            Id = registro.Id;
            Imagem = registro.Imagem;
            Titulo = registro.Titulo;
            Descricao = registro.Descricao;
            Duracao = registro.Duracao;            
        }

      

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, UsuarioId, Usuario, Imagem, Titulo, Descricao, Duracao, Sessoes);
        }

        public override bool Equals(object obj)
        {
            return obj is Filme filme &&
                   Id.Equals(filme.Id) &&
                   UsuarioId.Equals(filme.UsuarioId) &&
                   EqualityComparer<Usuario>.Default.Equals(Usuario, filme.Usuario) &&
                   Imagem == filme.Imagem &&
                   Titulo == filme.Titulo &&
                   Descricao == filme.Descricao &&
                   Duracao.Equals(filme.Duracao) &&
                   EqualityComparer<List<Sessao>>.Default.Equals(Sessoes, filme.Sessoes);
        }
    }
}
