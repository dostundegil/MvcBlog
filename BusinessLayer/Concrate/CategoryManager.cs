using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrate;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        //Kategori'yi pasif hale getirme
        public void CategoryStatusFalse(int id)
        {
            Category category = _categoryDal.Find(x => x.CategoryID == id);

            category.CategoryStatus = false;

            _categoryDal.Update(category);
        }

        //Kategori'yi aktif hale getirme
        public void CategoryStatusTrue(int id)
        {
            Category category = _categoryDal.Find(x => x.CategoryID == id);

            category.CategoryStatus = true;

            _categoryDal.Update(category);
        }

        //Listeleme İşlemi
        public List<Category> GetList()
        {
            return _categoryDal.List();
        }

        //Ekleme İşlemi
        public void TAdd(Category category)
        {
            _categoryDal.Insert(category);
        }

        //ID'ye göre veri getirme
        public Category GetByID(int id)
        {
            return _categoryDal.GetByID(id);
        }

        //Silme İşlemi
        public void TDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        //Güncelleme İşlemi
        public void TUpdate(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
