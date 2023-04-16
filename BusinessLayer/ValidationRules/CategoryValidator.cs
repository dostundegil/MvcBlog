using EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            //Kategori Adı
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adını Boş Geçemezsiniz");
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("Kategori Adı En Az 2 Karakterden Oluşmalıdır");
            RuleFor(x => x.CategoryName).MaximumLength(30).WithMessage("Kategori Adı En fazla 30 Karakterden Olabilir");

            //Kategori Açıklaması
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklamayı Boş Geçemezsiniz");
            RuleFor(x => x.CategoryDescription).MinimumLength(2).WithMessage("Açıklama En Az 2 Karakterden Oluşmalıdır");
            RuleFor(x => x.CategoryDescription).MaximumLength(500).WithMessage("Açıklama En fazla 500 Karakterden Olabilir");
        }
    }
}
