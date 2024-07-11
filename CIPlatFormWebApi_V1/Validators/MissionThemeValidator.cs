using FluentValidation;
using Data_Logic_Layer.Entity;

namespace CIPlatFormWebApi_V1.Validators
{
    public class MissionThemeValidator : AbstractValidator<Theme>
    {
        public MissionThemeValidator()
        {
            RuleFor(x => x.ThemeName)
                .NotEmpty().WithMessage("Theme name is required.")
                .MaximumLength(100).WithMessage("Theme name can't be longer than 100 characters.");

            RuleFor(x => x.ThemeDescription)
                .NotEmpty().WithMessage("Theme description is required.");

            RuleFor(x => x.ThemeImage)
                .NotEmpty().WithMessage("Theme image is required.")
                .Matches(@"\.(jpeg|jpg|png)$").WithMessage("Theme image must be a valid image file (jpg, jpeg, png).");
        }
    }
}
