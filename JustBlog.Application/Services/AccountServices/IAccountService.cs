using JustBlog.ViewModel.Accounts;
using JustBlog.ViewModel.IdentityResult;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JustBlog.Application.Services
{
    public interface IAccountService
    {
        Task<IdentityCustomResult> CreateAsync(CreateUserVm createUserVm);

        Task<IdentityCustomResult> SignInAsync(LoginVm loginVm);

        Task<IdentityCustomResult> UpdateAsyn(UpdateUserVm updateUserVm);

        Task<IdentityCustomResult> Delete(string id);

        Task<IEnumerable<UserVm>> GetAll();

        Task<UserVm> GetUserById(string userId);

        Task Logout();

        Task<IdentityCustomResult> GenerateToken(LoginVm request);
    }
}