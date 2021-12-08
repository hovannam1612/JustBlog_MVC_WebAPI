using JustBlog.ViewModel.BaseEntity;
using System;

namespace JustBlog.ViewModel.Posts
{
    public class PostViewModel : BaseEntityVm
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
    }
}