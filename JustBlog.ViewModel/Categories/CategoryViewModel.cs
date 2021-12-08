using JustBlog.ViewModel.BaseEntity;

namespace JustBlog.ViewModel.Categories
{
    public class CategoryViewModel : BaseEntityVm
    {
        public string UrlSlug { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}