using JustBlog.Infrastructure.IRepository;
using System;
using System.Threading.Tasks;

namespace JustBlog.Infrastructure.Infrastructures
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }

        IPostRepository PostRepository { get; }

        ITagRepository TagRepository { get; }

        ICommentRepository CommentRepository { get; }

        JustBlogDbContext JustBlogDbContext { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}