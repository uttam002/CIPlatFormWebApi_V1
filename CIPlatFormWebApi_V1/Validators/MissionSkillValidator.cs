using FluentValidation;
using Data_Logic_Layer.Entity;

namespace CIPlatFormWebApi_V1.Validators
{
    public class MissionSkillValidator : AbstractValidator<Skill>
    {
        public MissionSkillValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.")
                                .MaximumLength(100).WithMessage("Name can't be longer than 100 characters.");
            RuleFor(x => x.Status).NotNull().WithMessage("Status is required.");
        }
    }
}