using JustBlog.Common.Helpers;
using JustBlog.Infrastructure.Infrastructures;
using JustBlog.Infrastructure.IRepository;
using JustBlog.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace JustBlog.Infrastructure.Repositories
{
    public class TagRepository : BaseRepository<Tag, int>, ITagRepository
    {
        public TagRepository(JustBlogDbContext justBlogDbContext) : base(justBlogDbContext)
        {
        }

        public IEnumerable<int> AddTagByString(string tagNames)
        {
            var tags = tagNames.Split(';');

            foreach (var tag in tags)
            {
                var tagExisting = _dbSet.Where(x => x.Name.Trim().ToLower().Equals(tag.Trim().ToLower())).FirstOrDefault();
                if (tagExisting == null)
                {
                    var newTag = new Tag()
                    {
                        Name = tag,
                        UrlSlug = UrlHepler.FrientlyUrl(tag)
                    };

                    _dbSet.Add(newTag);
                }
            }

            _justBlogDbContext.SaveChanges();

            foreach (var tag in tags)
            {
                var tagExisting = _dbSet.Where(x => x.Name.ToLower().Equals(tag.ToLower())).FirstOrDefault();
                if (tagExisting != null)
                    yield return tagExisting.Id;
            }
        }

        public IEnumerable<Tag> FindTagsByPostId(int postId)
        {
            var tags = _dbSet
                .Join(_justBlogDbContext.PostTagMaps, t => t.Id, pt => pt.TagId, (t, pt) => new { t, pt })
                .Join(_justBlogDbContext.Posts, ppc => ppc.pt.PostId, p => p.Id, (ppc, p) => new { ppc, p })
                .Where(x => x.p.Id.Equals(postId)).Select(m => new Tag
                {
                    Id = m.ppc.t.Id,
                    Name = m.ppc.t.Name,
                    UrlSlug = m.ppc.t.UrlSlug
                });
            return tags.AsEnumerable();
        }

        public IEnumerable<Tag> GetTagAvailable()
        {
            
            var postIds = _justBlogDbContext.Posts.Where(x => x.IsDeleted.Equals(false)).Select(x => x.Id).ToArray(); //get post id have IsDeleted = false

            var postTags = _justBlogDbContext.PostTagMaps.Where(x => postIds.Contains(x.PostId));

            var tagIds = postTags.Select(x => x.TagId).ToArray();

            return GetById(tagIds);
        }
    }
}