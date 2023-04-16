﻿using BusinessLayer.Abstract;
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
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public List<Blog> GetBlogByID(int id)
        {
            return _blogDal.List(x => x.BlogID == id);
        }

        public List<Blog> GetBlogByAuthor(int id)
        {
            return _blogDal.List(x => x.AuthorID == id);
        }

        public List<Blog> GetBlogByCategory(int id)
        {
            return _blogDal.List(x => x.CategoryID == id);
        }

        public List<Blog> GetList()
        {
            return _blogDal.List();
        }

        public void TAdd(Blog blog)
        {
            _blogDal.Insert(blog);
        }

        public Blog GetByID(int id)
        {
            return _blogDal.GetByID(id);
        }

        public void TDelete(Blog blog)
        {
            _blogDal.Delete(blog);
        }

        public void TUpdate(Blog blog)
        {
            _blogDal.Update(blog);
        }
    }
}
