using JustBlog.Infrastructure.Infrastructures;
using JustBlog.Model.Entities;
using System.Collections.Generic;

namespace JustBlog.Infrastructure.IRepository
{
    public interface ITagRepository : IBaseRepository<Tag, int>
    {
        /// <summary>
        /// Find list tag by post id
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        IEnumerable<Tag> FindTagsByPostId(int postId);

        /// <summary>
        /// Add tags into Tags table by tagNames split by ';'
        /// </summary>
        /// <param name="tagNames">list of tags split by ';'</param>
        /// <returns>List Id of Tags was added</returns>
        IEnumerable<int> AddTagByString(string tagNames);

        /// <summary>
        /// Get all tag of post public
        /// </summary>
        /// <returns></returns>
        IEnumerable<Tag> GetTagAvailable();
    }
}