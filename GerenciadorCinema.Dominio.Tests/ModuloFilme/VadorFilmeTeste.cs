using FluentValidation.Results;
using GerenciadorCimena.Dominio.ModuloFilmes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GerenciadorCinema.Dominio.Tests.ModuloFilme
{
    [TestClass]
    public class VadorFilmeTeste
    {
        [TestMethod]
        public void Imagem_nao_Pode_Ser_Vazia()
        {
            Filme filme = new("", "Titulo Teste", "Descricao Teste", new TimeSpan (0, 2, 20, 0));

            ValidadorFilme validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(filme);

            //assert
            Assert.AreEqual("Imagem não pode ser vazia", resultado.Errors[0].ErrorMessage);
            
        }


        [TestMethod]
        public void Titulo_nao_Pode_Ser_Nulo()
        {
            Filme filme = new ("Imagem", null , "Descricao Teste", new TimeSpan(0, 2, 20, 0));

            ValidadorFilme validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(filme);

            //assert
            Assert.AreEqual("Titulo não pode ser nulo", resultado.Errors[0].ErrorMessage);
        }


        [TestMethod]
        public void Titulo_nao_Pode_Ser_Vazio()
        {
            Filme filme = new("Imagem", "", "Descricao Teste", new TimeSpan(0, 2, 20, 0));

            ValidadorFilme validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(filme);

            //assert
            Assert.AreEqual("Titulo não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }


        [TestMethod]
        public void Descricao_nao_Pode_Ser_Nulo()
        {
            Filme filme = new("Imagem", "Filme Teste", null, new TimeSpan(0, 2, 20, 0));

            ValidadorFilme validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(filme);

            //assert
            Assert.AreEqual("Descricao não pode ser nulo", resultado.Errors[0].ErrorMessage);
        }


        [TestMethod]
        public void Descricao_nao_Pode_Ser_Vazia()
        {
            Filme filme = new("Imagem", "Filme Teste", "", new TimeSpan(0, 2, 20, 0));

            ValidadorFilme validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(filme);

            //assert
            Assert.AreEqual("Descricao não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Duracao_nao_Pode_Ser_Vazia()
        {
            Filme filme = new("Imagem", "Filme Teste", " Descricao Teste", new TimeSpan());

            ValidadorFilme validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(filme);

            //assert
            Assert.AreEqual("Duracao não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }

    }
}
