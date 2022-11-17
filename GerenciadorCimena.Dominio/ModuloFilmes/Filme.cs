using GerenciadorCimena.Dominio.Compartilhado;
using GerenciadorCimena.Dominio.ModuloSessoes;
using System;
using System.Collections.Generic;


namespace GerenciadorCimena.Dominio.ModuloFilmes
{
    public class Filme : EntidadeBase<Filme>
    {        

        public byte[] Imagem { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public TimeSpan Duracao { get; set; }

        public List<Sessao> Sessoes { get; set; }        

        

        public Filme()
        {
        }

        public Filme(byte[] imagem, string titulo, string descricao, TimeSpan duracao)
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

        public override bool Equals(object obj)
        {
            Filme filme = obj as Filme;

            if (filme == null)
                return false;

            return
                filme.Id.Equals(Id) &&
                filme.Imagem.Equals(Imagem) &&
                filme.Titulo.Equals(Titulo) &&
                filme.Descricao.Equals(Descricao) &&
                filme.Duracao.Equals(Duracao);

        }

        
    }
}
