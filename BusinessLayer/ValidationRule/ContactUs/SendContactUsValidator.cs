using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRule.ContactUs
{
    public class SendContactUsValidator:AbstractValidator<SendMessageDto>
    {
        public SendContactUsValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail adresi boş geçilemez!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanı boş geçilemez!");
            RuleFor(x => x.MessageBody).NotEmpty().WithMessage("Mesaj alanı boş geçilemez!");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz!");
            RuleFor(x => x.Mail).MinimumLength(10).WithMessage("Lütfen en az 10 karakter girişi yapınız!");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapınız!");
            RuleFor(x => x.Subject).MinimumLength(4).WithMessage("Lütfen en az 4 karakter girişi yapınız!");
        }
    }
}
