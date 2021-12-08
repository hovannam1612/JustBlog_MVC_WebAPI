using AutoMapper;
using JustBlog.Common.Constants;
using JustBlog.Model.Entities;
using JustBlog.ViewModel.Accounts;
using JustBlog.ViewModel.IdentityResult;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IPasswordHasher<AppUser> _passwordHasher;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AccountService(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IPasswordHasher<AppUser> passwordHasher,
            IMapper mapper,
            IConfiguration configuration)
        {
            _passwordHasher = passwordHasher;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<IdentityCustomResult> CreateAsync(CreateUserVm createUserVm)
        {
            var user = new AppUser()
            {
                FullName = createUserVm.FullName,
                UserName = createUserVm.UserName,
                Email = createUserVm.Email
            };

            if (_userManager.Users.Any(x => x.UserName.ToLower().Equals(user.UserName.ToLower())))
            {
                return new ErrorResult("Tên đăng nhập đã tồn tại");
            }
            if (_userManager.Users.Any(x => x.Email.ToLower().Equals(user.Email.ToLower())))
            {
                return new ErrorResult("Email đã tồn tại");
            }
            var roleNames = createUserVm.RoleName;
            foreach (var item in roleNames)
            {
                if (item != UserRole.BlogOwner && item != UserRole.User && item != UserRole.Contributor)
                    return new ErrorResult("Role name không hợp lệ (User, Contributor, Blog Owner)");
            }
            var result = await _userManager.CreateAsync(user, createUserVm.Password);
            if (result.Succeeded)
            {
                //add role
                await _userManager.AddToRolesAsync(user, roleNames);

                return new SuccessResult("Đăng ký thành công");
            }

            return new ErrorResult("Đăng ký thất bại");
        }

        public async Task<IdentityCustomResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return new SuccessResult("Xóa thành công");
            }
            return new ErrorResult("Xóa thất bại");
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityCustomResult> SignInAsync(LoginVm loginVm)
        {
            var user = await _userManager.FindByNameAsync(loginVm.UserName);
            if (user == null)
                return new ErrorResult("Tên đăng nhập không tồn tại");

            var result = await _signInManager.PasswordSignInAsync(user, loginVm.Password, true, true);
            if (result.Succeeded)
                return new SuccessResult("Đăng nhập thành công");

            return new ErrorResult("Đăng nhập thất bại");
        }

        public async Task<IdentityCustomResult> UpdateAsyn(UpdateUserVm updateUserVm)
        {
            var user = await _userManager.FindByIdAsync(updateUserVm.Id);

            if (user != null)
            {
                user.UserName = updateUserVm.UserName;
                user.Email = updateUserVm.Email;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                    result = await ResetPassword(user, updateUserVm.Password);
                if (result.Succeeded)
                    result = await UpdateRoleForUser(user, updateUserVm.RoleName);
                if (result.Succeeded)
                {
                    return new SuccessResult("Update thành công");
                }
            }

            return new SuccessResult("Update thất bại");
        }

        public async Task<IdentityResult> ResetPassword(AppUser user, string password)
        {
            if (_passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password) != PasswordVerificationResult.Success)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                return await _userManager.ResetPasswordAsync(user, token, password);
            }
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> UpdateRoleForUser(AppUser user, List<string> userRoleNames)
        {
            var oldRoles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, oldRoles);
            if (result.Succeeded)
                result = await _userManager.AddToRolesAsync(user, userRoleNames);
            return result;
        }

        public async Task<IEnumerable<UserVm>> GetAll()
        {
            var users = _userManager.Users.ToList();
            var vmList = new List<UserVm>();
            foreach (var item in users)
            {
                var userVm = new UserVm();
                var roleNames = await _userManager.GetRolesAsync(item);
                userVm.FullName = item.FullName;
                userVm.Email = item.Email;
                userVm.Id = item.Id;
                userVm.UserName = item.UserName;
                userVm.RoleNames = roleNames;
                vmList.Add(userVm);
            }

            return vmList;
        }

        public async Task<UserVm> GetUserById(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var usrVm = new UserVm()
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    FullName = user.FullName,
                    RoleNames = roles
                };

                return usrVm;
            }
            return null;
        }

        public async Task<IdentityCustomResult> GenerateToken(LoginVm request)
        {
            var result = await SignInAsync(request);
            if (result.IsSuccessed)
            {
                var user = await _userManager.FindByNameAsync(request.UserName);
                //var roles = await _userManager.GetRolesAsync(user);
                var claims = new[]
                {
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Name,user.UserName),
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                   issuer: _configuration["Jwt:Issuer"],
                   audience: _configuration["Jwt:Audience"],
                   claims: claims,
                   expires: DateTime.Now.AddHours(1),
                   signingCredentials: creds
                );

                return new SuccessResult(new JwtSecurityTokenHandler().WriteToken(token));
            }

            return new ErrorResult("Login failed");
        }
    }
}