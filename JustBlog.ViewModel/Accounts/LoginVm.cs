using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.ViewModel.Accounts
{
    public class LoginVm
    {
        [Required(ErrorMessage = "Tên đăng nhập không được trống")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password, ErrorMessage = "Password không hợp lệ")]
        [StringLength(100, ErrorMessage = "Password phải ít nhất {2} kí tự và tối đa {1} kí tự", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
