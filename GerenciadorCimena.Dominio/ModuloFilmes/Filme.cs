using GerenciadorCimena.Dominio.Compartilhado;
using GerenciadorCimena.Dominio.ModuloAutenticacao;
using GerenciadorCimena.Dominio.ModuloSessoes;
using System;
using System.Collections.Generic;


namespace GerenciadorCimena.Dominio.ModuloFilmes
{
    public class Filme : EntidadeBase<Filme>
    {        

        

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


        public string Imagem { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public TimeSpan Duracao { get; set; }

        public List<Sessao> Sessoes { get; set; }


        public override void Atualizar(Filme registro)
        {
            Id = registro.Id;
            Imagem = registro.Imagem;
            Titulo = registro.Titulo;
            Descricao = registro.Descricao;
            Duracao = registro.Duracao;            
        }

        public override bool Equals(object obj)
        {
            return obj is Filme filme &&
                   Id.Equals(filme.Id) &&
                   Imagem == filme.Imagem &&
                   Titulo == filme.Titulo &&
                   Descricao == filme.Descricao &&
                   Duracao.Equals(filme.Duracao) &&
                   EqualityComparer<List<Sessao>>.Default.Equals(Sessoes, filme.Sessoes);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Imagem, Titulo, Descricao, Duracao, Sessoes);
        }
    }
}
