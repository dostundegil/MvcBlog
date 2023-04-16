using DataAccessLayer.Concrate;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class UserProfileManager
    {
        Repository<Author> repoUser = new Repository<Author>();
        Repository<Blog> repoUserBlog = new Repository<Blog>();
        public List<Author> GetAuthorByMail(string p)
        {
            return repoUser.List(x => x.AuthorMail == p);
        }
        public List<Blog> GetBlogByAuthor(int id)
        {
            return repoUserBlog.List(x => x.AuthorID == id);
        }
        public void UpdateAuthor(Author p)
        {
            Author author = repoUser.Find(x => x.AuthorID == p.AuthorID);
            author.AuthorName = p.AuthorName;
            author.AuthorImage = p.AuthorImage;
            author.AuthorAbout = p.AuthorAbout;
            author.AuthorTitle = p.AuthorTitle;
            author.AboutShrot = p.AboutShrot;
            author.AuthorMail = p.AuthorMail;
            author.AuthorPassword = p.AuthorPassword;
            author.AuthorPhone = p.AuthorPhone;
            repoUser.Update(author);
        }
    }
}
