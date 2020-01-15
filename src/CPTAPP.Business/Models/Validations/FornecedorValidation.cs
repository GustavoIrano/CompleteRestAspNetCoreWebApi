using AppMvc.Models;
using FluentValidation;

namespace CPTAPP.Business.Validations
{
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        public FornecedorValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} não pode ser vazio!")
                .Length(5, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            When(f => f.TipoFornecedor == TipoFornecedor.PessoaFisica, () => {
                RuleFor(f => f.Documento.Length).Equal(12)
                .WithMessage("O documento precisa ter 12 caracteres");
            });

            When(f => f.TipoFornecedor == TipoFornecedor.PessoaJuridica, () => { });          
            
        }
    }
}
