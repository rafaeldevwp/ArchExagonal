using Bussiness.Entidades;
using FluentValidation;

namespace Bussiness.Services.ValidadorEntidades
{
    public class ProfessorValidator : AbstractValidator<Professor>
    {
        public ProfessorValidator()
        {
            RuleFor(professor => professor.ProfessorId)
                .NotEmpty().WithMessage("O ID do professor é obrigatório.");

            RuleFor(professor => professor.Nome)
                .NotEmpty().WithMessage("O nome do professor é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do professor não pode ter mais de 100 caracteres.");

            // RuleFor(professor => professor.Status)
            //     .InclusiveBetween(0, 2).WithMessage("O status do professor deve estar entre 0 e 2.");

            RuleFor(professor => professor.Cursos)
                .NotEmpty().WithMessage("Pelo menos um curso deve estar associado ao professor.")
                .ForEach(curso => curso.SetValidator(new CursoValidator())); // Usar o validador para Curso

            RuleFor(professor => professor.DataCadastro)
                .NotEmpty().WithMessage("A data de cadastro do professor é obrigatória.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de cadastro não pode ser no futuro.");

            RuleFor(professor => professor.DataAlteracao)
                .NotEmpty().WithMessage("A data de alteração do professor é obrigatória.")
                .GreaterThanOrEqualTo(professor => professor.DataCadastro).WithMessage("A data de alteração deve ser igual ou após a data de cadastro.");
        }
    }
}