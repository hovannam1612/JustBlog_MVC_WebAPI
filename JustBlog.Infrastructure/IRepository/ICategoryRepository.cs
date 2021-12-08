using JustBlog.Infrastructure.Infrastructures;
using JustBlog.Model.Entities;

namespace JustBlog.Infrastructure.IRepository
{
    public interface ICategoryRepository : IBaseRepository<Category, int>
    {
    }
}