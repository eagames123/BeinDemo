using DiziFilm.Project.Entities.Concrete;
using FluentValidation;

namespace DiziFilm.Project.Business.ValidationRules.FluentValidation
{
    public class FilmValidator:AbstractValidator<Film>
    {
        public FilmValidator()
        {
            RuleFor(f => f.Name).NotEmpty().WithMessage("Film Ad alanı boş olamaz");

            RuleFor(f => f.Category).NotEmpty().WithMessage("Kategori alanı boş olamaz");

            RuleFor(f => f.Category).NotNull().WithMessage("Kategori alanı boş olamaz");
            
            RuleFor(f => f.Detail).NotEmpty().WithMessage("Detay alanı boş olamaz");

            RuleFor(f => f.Fragman).NotEmpty().WithMessage("Fragman alanı boş olamaz");
        }
    }
}
