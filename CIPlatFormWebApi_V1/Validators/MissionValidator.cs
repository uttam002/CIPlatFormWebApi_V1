using FluentValidation;
using Data_Logic_Layer.Entity;
using Data_Logic_Layer.Migrations;

namespace CIPlatFormWebApi_V1.Validators
{
    public class MissionValidator : AbstractValidator<MissionDto>
    {
        public MissionValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title can't be longer than 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Start Date is required.")
                .LessThan(x => x.EndDate).WithMessage("Start Date must be before End Date.")
                .GreaterThan(DateTime.Now).WithMessage("Start Date must be in the future.");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("End Date is required.")
                .GreaterThan(x => x.StartDate).WithMessage("End Date must be after Start Date.");

            RuleFor(x => x.Deadline)
                .NotEmpty().WithMessage("Deadline is required.")
                .LessThanOrEqualTo(x => x.EndDate).WithMessage("Deadline must be on or before the End Date.")
                .GreaterThanOrEqualTo(x => x.StartDate).WithMessage("Deadline must be on or after the Start Date.");
        }
    }
}
