using FluentValidation;


namespace GerenciadorCimena.Dominio.ModuloFilmes
{
    public class ValidadorFilme : AbstractValidator<Filme>
    {
        public ValidadorFilme()
        {

            RuleFor(x => x.Imagem)
               .NotEmpty().WithMessage("Imagem não pode ser vazia");

            RuleFor(x => x.Titulo)
               .NotNull().WithMessage("Titulo não pode ser nulo")
               .NotEmpty().WithMessage("Titulo não pode ser vazio");

            RuleFor(x => x.Descricao)
               .NotNull().WithMessage("Descricao não pode ser nulo")
               .NotEmpty().WithMessage("Descricao não pode ser vazio");

            RuleFor(x => x.Duracao)               
               .NotEmpty().WithMessage("Duracao não pode ser vazio");        

        }

    }
}
