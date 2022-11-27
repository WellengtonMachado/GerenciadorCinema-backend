using GerenciadorCimena.Dominio.Compartilhado;
using GerenciadorCimena.Dominio.ModuloAutenticacao;
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




        public DateTime Data { get; set; }

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
                   Id.Equals(sessao.Id) &&
                   EqualityComparer<Filme>.Default.Equals(_filme, sessao._filme) &&
                   EqualityComparer<Sala>.Default.Equals(_sala, sessao._sala) &&
                   Data == sessao.Data &&
                   HorarioInicio.Equals(sessao.HorarioInicio) &&
                   HorarioFim.Equals(sessao.HorarioFim) &&
                   ValorIngresso == sessao.ValorIngresso &&
                   Animacao == sessao.Animacao &&
                   Audio == sessao.Audio &&
                   EqualityComparer<Filme>.Default.Equals(Filme, sessao.Filme) &&
                   EqualityComparer<Guid?>.Default.Equals(FilmeId, sessao.FilmeId) &&
                   EqualityComparer<Sala>.Default.Equals(Sala, sessao.Sala) &&
                   EqualityComparer<Guid?>.Default.Equals(SalaId, sessao.SalaId);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(_filme);
            hash.Add(_sala);
            hash.Add(Data);
            hash.Add(HorarioInicio);
            hash.Add(HorarioFim);
            hash.Add(ValorIngresso);
            hash.Add(Animacao);
            hash.Add(Audio);
            hash.Add(Filme);
            hash.Add(FilmeId);
            hash.Add(Sala);
            hash.Add(SalaId);
            return hash.ToHashCode();
        }

        public bool NaoExcluirAntesDezDias()
        {
            return (Data - DateTime.Now).TotalDays < 10;
        }


    }

}