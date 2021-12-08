using JustBlog.ViewModel.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.ViewModel.Comments
{
    public class CommentVm : BaseEntityVm
    {
        public string Name { get; set; }

        public string CommentText { get; set; }

        public int PostId { get; set; }
    }
}
