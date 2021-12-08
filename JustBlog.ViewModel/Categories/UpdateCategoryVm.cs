using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.ViewModel.Categories
{
    public class UpdateCategoryVm
    {
        public int Id { get; set; }

        [DisplayName("Tên Danh Mục")]
        [StringLength(100, ErrorMessage = "{0} phải từ {2} đến {1} ký tự.", MinimumLength = 2)]
        [Required(ErrorMessage = "{0} không được để trống")]
        public string Name { get; set; }
        
        [DisplayName("Link Url")]
        [StringLength(50, ErrorMessage = "{0} phải từ {2} đến {1} ký tự.", MinimumLength = 2)]
        [Required(ErrorMessage = "{0} không được để trống")]
        public string UrlSlug { get; set; }


        [DisplayName("Mô Tả")]
        [StringLength(200, ErrorMessage = "{0} phải từ {2} đến {1} ký tự.", MinimumLength = 2)]
        public string Description { get; set; }
    }
}
