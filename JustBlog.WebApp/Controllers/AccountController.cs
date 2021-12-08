using JustBlog.Application.Services;
using JustBlog.ViewModel.Accounts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace JustBlog.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger, IAccountService accountService)
        {
            _accountService = accountService;
            _logger = logger;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateUserVm registerVm)
        {
            if (!ModelState.IsValid)
                return View(registerVm);
            var result = await _accountService.CreateAsync(registerVm);

            if (result.IsSuccessed)
                TempData["RegisterSuccess"] = result.Message;
            else
                TempData["RegisterFail"] = result.Message;
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVm loginVm)
        {
            if (!ModelState.IsValid)
                return View(loginVm);

            var result = await _accountService.SignInAsync(loginVm);

            if (result.IsSuccessed)
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }

            TempData["LoginFail"] = result.Message;

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _accountService.Logout();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AccessDenied()
        {
            return PartialView("~/Views/Account/AccessDenied.cshtml");
        }
    }
}