using EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            //Ad
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu Alanı Boş Geçemezsiniz");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Bu Alana En fazla 50 Karakter Girebilirsiniz");

            //Soyad
            RuleFor(x => x.SurName).NotEmpty().WithMessage("Bu Alanı Boş Geçemezsiniz");
            RuleFor(x => x.SurName).MaximumLength(50).WithMessage("Bu Alana En fazla 50 Karakter Girebilirsiniz");

            //Mail
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Bu Alanı Boş Geçemezsiniz");
            RuleFor(x => x.Mail).MinimumLength(10).WithMessage("Bu Alana En Az 10 Karakter Girebilirsiniz");
            RuleFor(x => x.Mail).MaximumLength(50).WithMessage("Bu Alana En fazla 50 Karakter Girebilirsiniz");

            //Konu
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Bu Alanı Boş Geçemezsiniz");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Bu Alana En fazla 50 Karakter Girebilirsiniz");

            //Mesaj
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Bu Alanı Boş Geçemezsiniz");

        }
    }
}
