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

        RuleFor(aluno => aluno.Matricula)
            .NotNull().WithMessage("A matrícula do aluno é obrigatória.")
            .SetValidator(new MatriculaValidator()); // Usar o validador para Matricula
    }

    // Função para validar CPF (exemplo simples)
    private bool BeAValidCPF(decimal cpf)
    {
        // Implementar lógica para validar o CPF aqui
        // Retornar true se for válido, senão false
        return true; // Temporário, até você implementar a lógica real
    }
    }
}