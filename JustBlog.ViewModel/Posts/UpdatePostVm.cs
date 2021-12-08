using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JustBlog.ViewModel.Posts
{
    public class UpdatePostVm
    {
        public int Id { get; set; }

        [DisplayName("Tiêu đề bài viết")]
        [StringLength(50, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        [Required(ErrorMessage = "{0} không được để trống")]
        public string Title { get; set; }

        [DisplayName("Nội dung bài viết")]
        [Required(ErrorMessage = "{0} không được để trống")]
        public string PostContent { get; set; }

        [DisplayName("Mô tả ngắn")]
        [StringLength(50, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        [Required(ErrorMessage = "{0} không được để trống")]
        public string ShortDescription { get; set; }

        [DisplayName("Link Url")]
        [Required(ErrorMessage = "{0} không được để trống")]
        public string UrlSlug { get; set; }

        [DisplayName("Thuộc về danh mục")]
        [Required(ErrorMessage = "{0} không được để trống")]
        public int CategoryId { get; set; }

        [DisplayName("Danh sách tag (cách nhau bởi dấu ';')")]
        [Required(ErrorMessage = "{0} không được để trống")]
        public string Tags { get; set; }
    }
}