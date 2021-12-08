using JustBlog.Application.Services.Comments;
using JustBlog.ViewModel.Comments;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustBlog.WebApp.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public IActionResult CommentPost(string postId, string name, string commentText)
        {
            var commentNew = new CreateCommentVm()
            {
                PostId = int.Parse(postId),
                Name = name,
                CommentText = commentText
            };
            _commentService.Create(commentNew);
            return RedirectToAction("PostDetail", "Post", new { id = postId });
        }
    }
}
