using JustBlog.Infrastructure.Infrastructures;
using JustBlog.Infrastructure.IRepository;
using JustBlog.Model.Entities;

namespace JustBlog.Infrastructure.Repositories
{
    public class CommentRepository : BaseRepository<Comment, int>, ICommentRepository
    {
        public CommentRepository(JustBlogDbContext justBlogDbContext) : base(justBlogDbContext)
        {
        }
    }
}