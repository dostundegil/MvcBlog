using EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValitador : AbstractValidator<Blog>
    {
        public BlogValitador()
        {
            //Blog Başlığı
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog Başlığını Boş Geçemezsiniz");
            RuleFor(x => x.BlogTitle).MinimumLength(2).WithMessage("Blog Başlığı En Az 2 Karakterden Oluşmalıdır");
            RuleFor(x => x.BlogTitle).MaximumLength(100).WithMessage("Blog Başlığı En fazla 100 Karakter Olabilir");

            //Blog İçerik Alanı
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("İçeriği Boş Geçemezsiniz");
            RuleFor(x => x.BlogContent).MinimumLength(100).WithMessage("İçerik En Az 100 Karakterden Oluşmalıdır");

            //Blog Resim Alanı
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Resim Alanını Boş Geçemezsiniz");
            RuleFor(x => x.BlogImage).MaximumLength(100).WithMessage("En Fazla 100 Karakter Girebilirsiniz");

            //Blog Yazar Alanı
            RuleFor(x => x.AuthorID).NotEmpty().WithMessage("Bu Alanı Boş Geçemezsiniz");

            //Blog Tarih Alanı
            RuleFor(x => x.BlogDate).NotEmpty().WithMessage("Bu Alanı  Boş Geçemezsiniz");

            //Blog Tarih Alanı
            RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Bu Alanı  Boş Geçemezsiniz");
        }
    }
}
