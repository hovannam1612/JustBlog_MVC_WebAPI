using JustBlog.Model.EntityBase;
using System;
using System.Collections.Generic;

namespace JustBlog.Model.Entities
{
    public class Post : BaseEntity<int>
    {
        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string PostContent { get; set; }

        public string UrlSlug { get; set; }

        public string Modified { get; set; }

        public int ViewCount { get; set; }

        public int RateCount { get; set; }

        public int TotalRate { get; set; }

        public DateTime PostedOn { get; set; }

        public bool Published { get; set; }

        public decimal Rate => TotalRate / RateCount;

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<PostTagMap> PostTagMaps { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}