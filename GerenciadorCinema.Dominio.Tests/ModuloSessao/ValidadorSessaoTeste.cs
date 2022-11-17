using FluentValidation.Results;
using GerenciadorCimena.Dominio.ModuloFilmes;
using GerenciadorCimena.Dominio.ModuloSalas;
using GerenciadorCimena.Dominio.ModuloSessoes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GerenciadorCinema.Dominio.Tests.ModuloSessao
{
    [TestClass]
    public class ValidadorSessaoTeste
    {
        [TestMethod]
        public void Data_nao_Pode_Ser_Vaziao()
        {
            Sessao sessao = new (default , new TimeSpan(0, 2, 20, 0) , new TimeSpan(0, 4, 30, 0) , new decimal( 35.00)  , TipoAnimacaoEnum.TresD , TipoAudioEnum.Dublado , new Filme() , new Sala() );

            ValidadorSessao validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(sessao);

            //assert
            Assert.AreEqual("Data não pode ser vazia", resultado.Errors[0].ErrorMessage);
        }

       

         [TestMethod]
        public void Data_nao_Pode_Ser_Antes_de_Hoje()
        {
            Sessao sessao = new(new DateTime(2022, 10, 13, 0, 0, 0), new TimeSpan(0, 2, 20, 0), new TimeSpan(0, 4, 30, 0), new decimal(35.00), TipoAnimacaoEnum.DoisD, TipoAudioEnum.Dublado, new Filme(), new Sala());

            ValidadorSessao validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(sessao);

            //assert
            Assert.AreEqual("A data não pode ser antes de hoje", resultado.Errors[0].ErrorMessage);
        }


        [TestMethod]
        public void Hora_Inicio_Nao_Pode_Ser_vazia()
        {
            Sessao sessao = new(new DateTime(2022, 11, 13, 0, 0, 0), default , new TimeSpan(0, 4, 30, 0), new decimal(35.00), TipoAnimacaoEnum.TresD, TipoAudioEnum.Dublado, new Filme(), new Sala());

            ValidadorSessao validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(sessao);

            //assert
            Assert.AreEqual("Horario de inicio não pode ser Vazia", resultado.Errors[0].ErrorMessage);
        }
            

        [TestMethod]
        public void Igresso_Nao_Pode_Ser_vazio()
        {
            Sessao sessao = new(new DateTime(2022, 11, 13, 0, 0, 0), new TimeSpan(0, 2, 20, 0), new TimeSpan(0, 4, 30, 0), default, TipoAnimacaoEnum.TresD, TipoAudioEnum.Dublado, new Filme(), new Sala());

            ValidadorSessao validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(sessao);

            //assert
            Assert.AreEqual("Valor do ingresso não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }

        //[TestMethod]
        //public void Animacao_Nao_Pode_Ser_vazia()
        //{
        //    Sessao sessao = new(new DateTime(2022, 11, 13, 0, 0, 0), new TimeSpan(0, 2, 20, 0), new TimeSpan(0, 4, 30, 0), new decimal(35.00), default, TipoAudioEnum.Original, new Filme(), new Sala());

        //    ValidadorSessao validacao = new();

        //    //action
        //    ValidationResult resultado = validacao.Validate(sessao);

        //    //assert
        //    Assert.AreEqual("Animacao não pode ser vazia", resultado.Errors[0].ErrorMessage);
        //}


        //[TestMethod]
        //public void Audio_Nao_Pode_Ser_vazia()
        //{
        //    Sessao sessao = new(new DateTime(2022, 11, 13, 0, 0, 0), new TimeSpan(0, 2, 20, 0), new TimeSpan(0, 4, 30, 0), new decimal(35.00),  TipoAnimacaoEnum.DoisD, default, new Filme(), new Sala());

        //    ValidadorSessao validacao = new();

        //    //action
        //    ValidationResult resultado = validacao.Validate(sessao);

        //    //assert
        //    Assert.AreEqual("Audio não pode ser vazio", resultado.Errors[0].ErrorMessage);
        //}


      

    }
}
