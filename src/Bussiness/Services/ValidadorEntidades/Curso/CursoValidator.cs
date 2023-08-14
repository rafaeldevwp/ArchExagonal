using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Bussiness.Entidades;

namespace Bussiness.Services.ValidadorEntidades
{
    public class CursoValidator : AbstractValidator<Curso>
    {
         public CursoValidator()
    {
        RuleFor(curso => curso.CursoId)
            .NotEmpty().WithMessage("O ID do curso é obrigatório.");

        RuleFor(curso => curso.Nome)
            .NotEmpty().WithMessage("O nome do curso é obrigatório.")
            .MaximumLength(100).WithMessage("O nome do curso não pode ter mais de 100 caracteres.");

        RuleFor(curso => curso.Status)
            .InclusiveBetween(0, 2).WithMessage("O status do curso deve estar entre 0 e 2.");

        RuleFor(curso => curso.Professor)
            .NotNull().WithMessage("O professor associado ao curso é obrigatório.")
            .SetValidator(new ProfessorValidator()); // Usar o validador para Professor
    }
    }
}