using JustBlog.ViewModel.Comments;
using System.Collections.Generic;

namespace JustBlog.Application.Services.Comments
{
    public interface ICommentService
    {
        IEnumerable<CommentVm> GetAll();

        IEnumerable<CommentVm> GetByPostId(int postId);

        CommentVm FindById(int id);

        bool Create(CreateCommentVm commentVm);

        bool Update(UpdateCommentVm commentVm);

        bool Delete(int id);

    }
}