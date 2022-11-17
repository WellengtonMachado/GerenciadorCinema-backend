using GerenciadorCimena.Dominio.Compartilhado;
using GerenciadorCimena.Dominio.ModuloFilmes;
using GerenciadorCimena.Dominio.ModuloSalas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorCimena.Dominio.ModuloSessoes
{
    public class Sessao : EntidadeBase<Sessao>
    {
        private DateTime _date;
        private Filme _filme;
        private Sala _sala;

        public Sessao()
        {

        }

        public Sessao(DateTime data, TimeSpan horarioInicio, TimeSpan horarioFim, decimal valorIngresso, TipoAnimacaoEnum animacao, TipoAudioEnum audio, Filme filme, Sala sala)
        {
            Data = data;
            HorarioInicio = horarioInicio;
            HorarioFim = horarioFim;
            ValorIngresso = valorIngresso;
            Animacao = animacao;
            Audio = audio;
            Filme = filme;
            Sala = sala;
        }


        public DateTime Data { get { return _date.Date; } set { _date = value; } }

        public TimeSpan HorarioInicio { get; set; }

        public TimeSpan HorarioFim { get; set; }

        public decimal ValorIngresso { get; set; }

        public TipoAnimacaoEnum Animacao { get; set; }

        public TipoAudioEnum Audio { get; set; }



        public Filme Filme
        {
            get { return _filme; }
            set
            {
                _filme = value;

                if (_filme != null)
                    FilmeId = _filme.Id;
            }
        }

        public Guid? FilmeId { get; set; }


        public Sala Sala
        {
            get { return _sala; }
            set
            {
                _sala = value;

                if (_sala != null)
                    SalaId = _sala.Id;
            }
        }

        public Guid? SalaId { get; set; }






        public override void Atualizar(Sessao registro)
        {
            Id = registro.Id;
            Data = registro.Data;
            HorarioInicio = registro.HorarioInicio;
            HorarioFim = registro.HorarioFim;
            ValorIngresso = registro.ValorIngresso;
            Animacao = registro.Animacao;
            Audio = registro.Audio;
            Filme = registro.Filme;
            Sala = registro.Sala;
        }

        public override bool Equals(object obj)
        {
            return obj is Sessao sessao &&
                   Id == sessao.Id &&
                   Data == sessao.Data &&
                   HorarioInicio == sessao.HorarioInicio &&
                   HorarioFim == sessao.HorarioFim &&
                   ValorIngresso == sessao.ValorIngresso &&
                   Animacao == sessao.Animacao &&
                   Audio == sessao.Audio &&
                   Filme == sessao.Filme &&
                   Sala == sessao.Sala &&
                   EqualityComparer<Filme>.Default.Equals(Filme, sessao.Filme) &&
                   EqualityComparer<Sala>.Default.Equals(Sala, sessao.Sala); 
        }




    }
}
