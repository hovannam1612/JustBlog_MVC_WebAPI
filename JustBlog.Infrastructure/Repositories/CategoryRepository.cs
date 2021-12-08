using JustBlog.Infrastructure.Infrastructures;
using JustBlog.Infrastructure.IRepository;
using JustBlog.Model.Entities;

namespace JustBlog.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(JustBlogDbContext justBlogDbContext) : base(justBlogDbContext)
        {
        }
    }
}