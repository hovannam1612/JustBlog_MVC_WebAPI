using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JustBlog.ViewModel.Accounts
{
    public class UpdateUserVm
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Họ tên không để trống")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập không được trống")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email không được trống")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password, ErrorMessage = "Password không hợp lệ")]
        [StringLength(100, ErrorMessage = "Password phải ít nhất {2} kí tự và tối đa {1} kí tự", MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password, ErrorMessage = "Password không hợp lệ")]
        [StringLength(100, ErrorMessage = "Password phải ít nhất {2} kí tự và tối đa {1} kí tự", MinimumLength = 6)]
        [Compare(nameof(Password), ErrorMessage = "Nhập lại mật khẩu không đúng")]
        public string ComfirmPassword { get; set; }

        [Required]
        [DisplayName("Role")]
        public List<string> RoleName { get; set; }
    }
}