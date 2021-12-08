using JustBlog.Model.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Model.Entities
{
    public class Category : BaseEntity<int>
    {
        public string Name { get; set; }

        public string UrlSlug { get; set; }

        public string Description { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
