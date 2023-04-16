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
    public class AboutManager:IAboutService
    {
        IAboutDal _aboutDal;
        Repository<About> repoAbout = new Repository<About>();

        public AboutManager(IAboutDal aboutDal)
        {
            this._aboutDal = aboutDal;
        }

        public List<About> GetList()
        {
            return _aboutDal.List();
        }

        public void TAdd(About about)
        {
            throw new NotImplementedException();
        }

        public About GetByID(int id)
        {
            return _aboutDal.Find(x => x.AboutID == id);
        }

        public void TDelete(About about)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(About about)
        {
            _aboutDal.Update(about);
        }
    }
}

