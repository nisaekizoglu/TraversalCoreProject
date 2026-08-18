using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRule
{
    public class AppUserRegisterValidator:AbstractValidator<AppUserRegisterDtos>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("ad alanı boş geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("soyad alanı boş geçilemez");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("mail alanı boş geçilemez");
            RuleFor(x => x.Username).NotEmpty().WithMessage("kullanıcı adı alanı boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("şifre alanı boş geçilemez");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("şifre alanı boş geçilemez");
        }
    }
}
