using JustBlog.Infrastructure.Infrastructures;
using JustBlog.Infrastructure.IRepository;
using JustBlog.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace JustBlog.Infrastructure.Repositories
{
    public class PostRepository : BaseRepository<Post, int>, IPostRepository
    {
        public PostRepository(JustBlogDbContext justBlogDbContext) : base(justBlogDbContext)
        {
        }

        public IEnumerable<Post> GetTopLatestPosts(int top, bool isDeleted = false)
        {
            if (!isDeleted)
            {
                return _dbSet.Where(x => x.IsDeleted.Equals(false)).OrderByDescending(x => x.CreatedOn).Take(top);
            }
            return _dbSet.AsEnumerable().OrderByDescending(x => x.CreatedOn).Take(top);
        }

        public IEnumerable<Post> GetTopMostViews(int top, bool isDeleted = false)
        {
            if (!isDeleted)
            {
                return _dbSet.Where(x => x.IsDeleted.Equals(false)).OrderByDescending(x => x.ViewCount).Take(top);
            }
            return _dbSet.AsEnumerable().OrderByDescending(x => x.ViewCount).Take(top);
        }
    }
}