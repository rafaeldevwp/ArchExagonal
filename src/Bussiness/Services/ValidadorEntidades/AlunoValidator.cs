using Bussiness.Entidades;
using Bussiness.Services.ValidadorEntidades;
using FluentValidation;

namespace Bussiness.ValidadorEntidades
{
    public class AlunoValidator : AbstractValidator<Aluno>
    {
        public AlunoValidator()
        {
            RuleFor(aluno => aluno.AlunoId)
                .NotEmpty().WithMessage("O ID do aluno é obrigatório.");

            RuleFor(aluno => aluno.Nome)
                .NotEmpty().WithMessage("O nome do aluno é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do aluno não pode ter mais de 100 caracteres.");

            RuleFor(aluno => aluno.Idade)
                .InclusiveBetween(0, 150).WithMessage("A idade do aluno deve estar entre 0 e 150 anos.");

            RuleFor(aluno => aluno.CPF)
                .NotEmpty().WithMessage("O CPF do aluno é obrigatório.")
                .Must(BeAValidCPF).WithMessage("O CPF do aluno é inválido.");

        }

        // Função para validar CPF (exemplo simples)
        private bool BeAValidCPF(string cpf)
        {
       

            cpf.Replace(".", "").Replace("-", ""); // Remove os pontos e traço

            if (cpf.Length != 11 || !long.TryParse(cpf, out _))
                return false;

            int[] pesosPrimeiroDigito = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] pesosSegundoDigito = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int somaPrimeiroDigito = 0;
            for (int i = 0; i < 9; i++)
            {
                somaPrimeiroDigito += int.Parse(cpf[i].ToString()) * pesosPrimeiroDigito[i];
            }

            int restoPrimeiroDigito = somaPrimeiroDigito % 11;
            int primeiroDigitoVerificador = restoPrimeiroDigito < 2 ? 0 : 11 - restoPrimeiroDigito;

            if (int.Parse(cpf[9].ToString()) != primeiroDigitoVerificador)
                return false;

            int somaSegundoDigito = 0;
            for (int i = 0; i < 10; i++)
            {
                somaSegundoDigito += int.Parse(cpf[i].ToString()) * pesosSegundoDigito[i];
            }

            int restoSegundoDigito = somaSegundoDigito % 11;
            int segundoDigitoVerificador = restoSegundoDigito < 2 ? 0 : 11 - restoSegundoDigito;

            if (int.Parse(cpf[10].ToString()) != segundoDigitoVerificador)
                return false;

            return true;
        }
    }
}