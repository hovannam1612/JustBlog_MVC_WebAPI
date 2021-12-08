using JustBlog.ViewModel.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.ViewModel.Posts
{
    public class ListPostViewModel : BaseEntityVm
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
    }
}
