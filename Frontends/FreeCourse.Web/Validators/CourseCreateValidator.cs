using FluentValidation;
using FreeCourse.Web.Models.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeCourse.Web.Validators
{
    public class CourseCreateValidator: AbstractValidator<CourseCreateInput>
    {
        public CourseCreateValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name must have a value");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description must have a value");
            RuleFor(x => x.Feature.Duration).InclusiveBetween(1,int.MaxValue).WithMessage("Duration must have a value");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price must have a value").ScalePrecision(2, 6).WithMessage("wrong format");  // ₺₺₺₺.₺₺
        }
    }
}
