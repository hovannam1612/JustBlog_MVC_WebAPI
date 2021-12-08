using JustBlog.Application.Services.CategoryServices;
using JustBlog.Application.Services.PostServices;
using JustBlog.Infrastructure.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustBlog.WebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IPostService _postService;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService, IPostService postService)
        {
            _logger = logger;
            _categoryService = categoryService;
            _postService = postService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryDetail(int id)
        {
            var posts = _postService.FindByCategoryId(id);
            return View(posts);
        }
    }
}
