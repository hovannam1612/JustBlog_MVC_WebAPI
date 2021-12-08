using JustBlog.ViewModel.Tags;
using System.Collections.Generic;

namespace JustBlog.Application.Services.TagServices
{
    public interface ITagService
    {
        IEnumerable<TagViewModel> FindTagsByPostId(int postId);

        TagViewModel FindById(int tagId);

        IEnumerable<TagViewModel> GetTagAvailable();
    }
}