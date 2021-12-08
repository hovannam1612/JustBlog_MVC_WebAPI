using JustBlog.Application.Services.PostServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JustBlog.WebApp.Controllers
{
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly IPostService _postService;

        public PostController(ILogger<PostController> logger, IPostService postService)
        {
            _logger = logger;
            _postService = postService;
        }

        public IActionResult MostViewedPosts()
        {
            return PartialView("~/Views/Post/_ListPost.cshtml");
        }

        public IActionResult LatestPosts()
        {
            return PartialView("~/Views/Post/_ListPost.cshtml");
        }

        public IActionResult PostDetail(int id)
        {
            var post = _postService.FindById(id);
            return View(post);
        }

        public IActionResult DetailPostTag(int id)
        {
            var posts = _postService.FindByTagId(id);
            ViewBag.TagId = id;
            return View(posts);
        }

    }
}