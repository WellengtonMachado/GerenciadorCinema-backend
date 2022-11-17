using FluentValidation;
using System;


namespace GerenciadorCimena.Dominio.ModuloSessoes
{
    public class ValidadorSessao : AbstractValidator<Sessao>
    {
        public ValidadorSessao()
        {
            RuleFor(x => x.Data)              
               .NotEmpty().WithMessage("Data não pode ser vazia")
               .GreaterThanOrEqualTo((x) => DateTime.Now.Date).WithMessage("A data não pode ser antes de hoje");


            RuleFor(x => x.HorarioInicio)
              .NotEmpty().WithMessage("Horario de inicio não pode ser Vazia");
           

            RuleFor(x => x.ValorIngresso)
               .NotEmpty().WithMessage("Valor do ingresso não pode ser vazio");
               

            RuleFor(x => x.Animacao)              
              .NotNull().WithMessage("Animacao não pode ser vazia");


            RuleFor(x => x.Audio)             
              .NotNull().WithMessage("Audio não pode ser vazio");


            


        }
    }
}
