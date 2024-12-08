using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validationrules
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(w => w.Name).NotEmpty().WithMessage("Bu alan boş geçilemez.");
            RuleFor(w => w.Name).MaximumLength(200).WithMessage("Karekter sınırını geçtiniz.");
            RuleFor(w => w.Surname).NotEmpty().WithMessage("Bu alan boş geçilemez.");
            RuleFor(w => w.Surname).MaximumLength(200).WithMessage("Karekter sınırını geçtiniz.");
            RuleFor(w => w.Username).MaximumLength(200).WithMessage("Karekter sınırını geçtiniz.");
        }
    }
}
