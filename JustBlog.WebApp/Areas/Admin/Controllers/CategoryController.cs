using JustBlog.Application.Services.CategoryServices;
using JustBlog.Common.Constants;
using JustBlog.ViewModel.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JustBlog.WebApp.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetAll();
            return View(categories);
        }

        [Authorize(Roles = UserRole.Contributor + "," + UserRole.BlogOwner)]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = UserRole.Contributor + "," + UserRole.BlogOwner)]
        [HttpPost]
        public IActionResult Create(CreateCategoryVm createCategoryVm)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Tạo mới thất bại";
                return View(createCategoryVm);
            }

            var isSuccess = _categoryService.Create(createCategoryVm);
            if (isSuccess)
            {
                TempData["Message"] = "Tạo mới thành công";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        [Authorize(Roles = UserRole.BlogOwner)]
        public IActionResult Delete(int id)
        {
            var isDelete = _categoryService.Delete(id);
            if (isDelete)
                TempData["Message"] = "Xóa thành công";
            else
                TempData["Message"] = "Xóa thất bại";
            return RedirectToAction("Index", "Category");
        }

        [Authorize(Roles = UserRole.Contributor + "," + UserRole.BlogOwner)]
        public IActionResult Update(int id)
        {
            var postUpdate = _categoryService.FinByIdUpdate(id);
            return View(postUpdate);
        }

        [Authorize(Roles = UserRole.Contributor + "," + UserRole.BlogOwner)]
        [HttpPost]
        public IActionResult Update(UpdateCategoryVm updateCategoryVm)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Update thất bại";
                return View(updateCategoryVm);
            }

            var isSuccess = _categoryService.Update(updateCategoryVm);
            if (isSuccess)
            {
                TempData["Message"] = "Update thành công";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public IActionResult Detail(int id) {
            var category = _categoryService.FindById(id);
            return View(category);
        }
    }
}