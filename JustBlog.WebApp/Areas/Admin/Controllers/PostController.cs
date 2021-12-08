using JustBlog.Application.Services.PostServices;
using JustBlog.Common.Constants;
using JustBlog.Common.Constraints;
using JustBlog.Model.Entities;
using JustBlog.ViewModel.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JustBlog.WebApp.Areas.Admin.Controllers
{
    public class PostController : BaseController
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult Index(string keyword = null, string searchBy = Searching.CreatedOn, int pageIndex = 1,
            int pageSize = 4, string typeOfSoft = Sorting.ASC)
        {
            Func<Post, bool> filter = null;
            if (!string.IsNullOrEmpty(keyword))
            {
                ViewBag.Keyword = keyword;
                ViewBag.SearchBy = searchBy;
                keyword = keyword.ToLower();
                if (searchBy == Searching.Title)
                    filter = x => x.Title.ToLower().Contains(keyword);
                else
                    filter = x => x.PostContent.ToLower().Contains(keyword);
            }
            ViewBag.TypeOfSoft = typeOfSoft;
            var postPaged = _postService.GetPaging(filter: filter, searchBy: searchBy, pageIndex: pageIndex, pageSize: pageSize, typeOfSoft: typeOfSoft);
            return View(postPaged);
        }

        [Authorize(Roles = UserRole.Contributor + "," + UserRole.BlogOwner)]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = UserRole.Contributor + "," + UserRole.BlogOwner)]
        [HttpPost]
        public IActionResult Create(CreatePostVm createPostVm)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Tạo mới thất bại";
                return View(createPostVm);
            }

            var isSuccess = _postService.Create(createPostVm);
            if (isSuccess)
            {
                TempData["Message"] = "Tạo mới thành công";
                return RedirectToAction("Index", "Post");
            }
            return View();
        }

        [Authorize(Roles = UserRole.BlogOwner)]
        public IActionResult Delete(int id)
        {
            var isDelete = _postService.Delete(id);
            if (isDelete)
                TempData["Message"] = "Xóa thành công";
            else
                TempData["Message"] = "Xóa thất bại";
            return RedirectToAction("Index", "Post");
        }

        [Authorize(Roles = UserRole.Contributor + "," + UserRole.BlogOwner)]
        public IActionResult Update(int id)
        {
            var postUpdate = _postService.FinByIdUpdate(id);
            return View(postUpdate);
        }

        [Authorize(Roles = UserRole.Contributor + "," + UserRole.BlogOwner)]
        [HttpPost]
        public IActionResult Update(UpdatePostVm updatePostVm)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Update thất bại";
                return View(updatePostVm);
            }

            var isSuccess = _postService.Update(updatePostVm);
            if (isSuccess)
            {
                TempData["Message"] = "Update thành công";
                return RedirectToAction("Index", "Post");
            }
            return View();
        }

        [Authorize(Roles = UserRole.BlogOwner)]
        public IActionResult PublicPost(int id)
        {
            var posts = _postService.UpdateIsDeleted(id);
            if (posts)
                TempData["Message"] = "Update thành công";
            else
                TempData["Message"] = "Update thất bại";
            return RedirectToAction("Index", "Post");
        }

        public IActionResult PostDetail(int id)
        {
            var post = _postService.FindById(id);
            return View(post);
        }


    }
}