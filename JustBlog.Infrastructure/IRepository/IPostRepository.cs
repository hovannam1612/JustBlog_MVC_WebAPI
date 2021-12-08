using JustBlog.Infrastructure.Infrastructures;
using JustBlog.Model.Entities;
using System.Collections.Generic;

namespace JustBlog.Infrastructure.IRepository
{
    public interface IPostRepository : IBaseRepository<Post, int>
    {
        IEnumerable<Post> GetTopMostViews(int top, bool isDeleted = false);

        IEnumerable<Post> GetTopLatestPosts(int top, bool isDeleted = false);
    }
}