using FluentValidation;


namespace GerenciadorCimena.Dominio.ModuloSalas
{
    public class ValidadorSala : AbstractValidator<Sala>
    {
        public ValidadorSala()
        {           

            RuleFor(x => x.Nome)
               .NotNull().WithMessage("Nome não pode ser nulo")
               .NotEmpty().WithMessage("Nome não pode ser vazio");

            RuleFor(x => x.QuantidadeAssentos)               
               .NotEmpty().WithMessage("Quantidade de assentos não pode ser vazio");            

        }
    }
}
