using EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            //Yazar Başlığı
            RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Yazar Adını Boş Geçemezsiniz");
            RuleFor(x => x.AuthorName).MaximumLength(50).WithMessage("Yazar Adı En fazla 100 Karakter Olabilir");

            //Yazar Hakkında Alanı
            RuleFor(x => x.AuthorAbout).NotEmpty().WithMessage("Hakkında Kısmını Boş Geçemezsiniz");
            RuleFor(x => x.AuthorAbout).MinimumLength(50).WithMessage("Hakkında Kısmı En Az 50 Karakterden Oluşmalıdır");
            RuleFor(x => x.AuthorAbout).MaximumLength(250).WithMessage("Hakkında Kısmı En Fazla 250 Karakterden Oluşmalıdır");

            //Yazar Resim Alanı
            RuleFor(x => x.AuthorImage).NotEmpty().WithMessage("Resim Alanını Boş Geçemezsiniz");
            RuleFor(x => x.AuthorImage).MaximumLength(100).WithMessage("Resim Yolu Çok Uzun");

            //Yazar Statü Alanı
            RuleFor(x => x.AuthorTitle).NotEmpty().WithMessage("Lütfen Boş Bırakmayın");
            RuleFor(x => x.AuthorTitle).MinimumLength(5).WithMessage("En Az 5 Karakter Girin");
            RuleFor(x => x.AuthorTitle).MaximumLength(50).WithMessage("Burası En Fazla 50 Karakterden Oluşmalıdır");

            //Yazar Mail Alanı
            RuleFor(x => x.AuthorMail).NotEmpty().WithMessage("Lütfen Boş Bırakmayın");
            RuleFor(x => x.AuthorMail).MinimumLength(10).WithMessage("En Az 10 Karakter Girin");
            RuleFor(x => x.AuthorMail).MaximumLength(50).WithMessage("Burası En Fazla 50 Karakterden Oluşmalıdır");

            //Yazar Telefon Alanı
            RuleFor(x => x.AuthorPhone).NotEmpty().WithMessage("Lütfen Boş Bırakmayın");
            RuleFor(x => x.AuthorPhone).MinimumLength(10).WithMessage("En Az 10 Karakter Girin");
            RuleFor(x => x.AuthorPhone).MaximumLength(20).WithMessage("Burası En Fazla 20 Karakterden Oluşmalıdır");

            //Yazar Telefon Alanı
            RuleFor(x => x.AboutShrot).NotEmpty().WithMessage("Lütfen Boş Bırakmayın");
            RuleFor(x => x.AboutShrot).MinimumLength(10).WithMessage("En Az 10 Karakter Girin");
            RuleFor(x => x.AboutShrot).MaximumLength(100).WithMessage("Burası En Fazla 20 Karakterden Oluşmalıdır");


            //Yazar Şifre Alanı
            RuleFor(x => x.AboutShrot).NotEmpty().WithMessage("Lütfen Boş Bırakmayın");
            RuleFor(x => x.AboutShrot).MinimumLength(5).WithMessage("En Az 5 Karakter Girin");
            RuleFor(x => x.AboutShrot).MaximumLength(50).WithMessage("Burası En Fazla 50 Karakterden Oluşmalıdır");
        }
    }
}
