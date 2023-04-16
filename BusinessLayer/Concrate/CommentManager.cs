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
    public class CommentManager:ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            this._commentDal = commentDal;
        }

        public List<Comment> CommentByBlog(int id)
        {
            return _commentDal.List(x => x.BlogID == id && x.CommentStatus==true);
        }

        public List<Comment> CommentByStatusTrue()
        {
            return _commentDal.List(x => x.CommentStatus == true);
        }

        public List<Comment> CommentByStatusFalse()
        {
            return _commentDal.List(x => x.CommentStatus == false);
        }

        public void CommentStatusChangeFalse(int id)
        {
            Comment comment = _commentDal.Find(x => x.CommentID == id);
            comment.CommentStatus = false;
            _commentDal.Update(comment);
        }

        public void CommentStatusChangeTrue(int id)
        {
            Comment comment = _commentDal.Find(x => x.CommentID == id);
            comment.CommentStatus = true;
            _commentDal.Update(comment);
        }

        public List<Comment> GetList()
        {
            return _commentDal.List();
        }

        public Comment GetByID(int id)
        {
            throw new NotImplementedException();
        }
        

        public void TDelete(Comment comment)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Comment comment)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Comment t)
        {
            _commentDal.Insert(t);
        }
    }
}
