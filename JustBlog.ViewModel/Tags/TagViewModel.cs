using JustBlog.ViewModel.BaseEntity;

namespace JustBlog.ViewModel.Tags
{
    public class TagViewModel : BaseEntityVm
    {
        public string Name { get; set; }

        public string UrlSlug { get; set; }

        public string Description { get; set; }

        public int Count { get; set; }
    }
}