using JustBlog.Infrastructure.IRepository;
using JustBlog.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace JustBlog.Infrastructure.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JustBlogDbContext _justBlogDbContext;
        private ICategoryRepository _categoryRepository;
        private IPostRepository _postRepository;
        private ITagRepository _tagRepository;
        private ICommentRepository _commentRepository;

        public UnitOfWork(JustBlogDbContext justBlogDbContext)
        {
            _justBlogDbContext = justBlogDbContext;
        }

        public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(_justBlogDbContext);

        public IPostRepository PostRepository => _postRepository ??= new PostRepository(_justBlogDbContext);

        public ITagRepository TagRepository => _tagRepository ??= new TagRepository(_justBlogDbContext);

        public ICommentRepository CommentRepository => _commentRepository ??= new CommentRepository(_justBlogDbContext);

        public JustBlogDbContext JustBlogDbContext => _justBlogDbContext;

        public void Dispose()
        {
            _justBlogDbContext.Dispose();
        }

        public int SaveChanges()
        {
            return _justBlogDbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _justBlogDbContext.SaveChangesAsync();
        }
    }
}