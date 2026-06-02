using FluentValidation;
using SmartCourseSystem.API.DTOs.Course;

namespace SmartCourseSystem.API.Validators
{
    public class CreateCourseValidator : AbstractValidator<CreateCourseDto>
    {
        public CreateCourseValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.Price)
                .GreaterThan(0);
        }
    }
}
