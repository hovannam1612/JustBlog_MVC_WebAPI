using JustBlog.Model.EntityBase;
using System;

namespace JustBlog.Model.Entities
{
    public class Comment : BaseEntity<int>
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string CommentHeader { get; set; }

        public string CommentText { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; }
    }
}