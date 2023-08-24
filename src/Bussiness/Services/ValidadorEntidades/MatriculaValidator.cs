using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bussiness.Entidades;
using Bussiness.ValidadorEntidades;
using FluentValidation;

namespace Bussiness.Services.ValidadorEntidades
{
    public class MatriculaValidator : AbstractValidator<Matricula>
    {
        public MatriculaValidator()
        {
            RuleFor(matricula => matricula.DataCriacao)
            .NotEmpty().WithMessage("A data de criação da matrícula é obrigatória.");

        RuleFor(matricula => matricula.DataAlteracao)
            .NotEmpty().WithMessage("A data de alteração da matrícula é obrigatória.")
            .GreaterThanOrEqualTo(matricula => matricula.DataCriacao).WithMessage("A data de alteração deve ser maior ou igual à data de criação.");

        RuleFor(matricula => matricula.Status)
            .IsInEnum().WithMessage("O status da matrícula é inválido.");

        RuleFor(matricula => matricula.Aluno)
            .NotNull().WithMessage("A matrícula deve estar associada a um aluno.")
            .SetValidator(new AlunoValidator()); // Validador para a propriedade Aluno

        // RuleForEach(matricula => matricula.Curso)
        //     .NotNull().WithMessage("A matrícula deve estar associada a um curso.")
        //     .SetValidator(new CursoValidator()); 
         }

    }
}