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
    public class AuthorManager : IAuthorService
    {
        IAuthorDal _authorDal;

        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        //Yazarları listeleme
        public List<Author> GetList()
        {
            return _authorDal.List();
        }

        //Yeni yazar ekleme işlemi
        public void TAdd(Author author)
        {
            _authorDal.Insert(author);
        }

        //Yazarı ID'sine göre edit sayfasına taşıma
        public Author GetByID(int id)
        {
            return _authorDal.GetByID(id);
        }

        public void TDelete(Author author)
        {
            throw new NotImplementedException();
        }

        //Güncelleme İşlemi
        public void TUpdate(Author author)
        {
            _authorDal.Update(author);
        }
    }
}
