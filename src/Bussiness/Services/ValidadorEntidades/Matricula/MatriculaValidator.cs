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
            RuleFor(matricula => matricula.MatriculaId)
                .NotEmpty().WithMessage("O ID da matrícula é obrigatório.");

            RuleFor(matricula => matricula.DataCriacao)
                .NotEmpty().WithMessage("A data de criação da matrícula é obrigatória.");

            RuleFor(matricula => matricula.DataAlteracao)
                .NotEmpty().WithMessage("A data de alteração da matrícula é obrigatória.")
                .GreaterThanOrEqualTo(matricula => matricula.DataCriacao).WithMessage("A data de alteração deve ser igual ou após a data de criação.");

            RuleFor(matricula => matricula.Status)
                .InclusiveBetween(0, 2).WithMessage("O status da matrícula deve estar entre 0 e 2.");

            RuleFor(matricula => matricula.Aluno)
                .NotNull().WithMessage("O aluno associado à matrícula é obrigatório.")
                .SetValidator(new AlunoValidator()); // Usar o validador para Aluno

            RuleFor(matricula => matricula.Curso)
                .NotNull().WithMessage("O curso associado à matrícula é obrigatório.")
                .SetValidator(new CursoValidator()); // Usar o validador para Curso
        }

    }
}