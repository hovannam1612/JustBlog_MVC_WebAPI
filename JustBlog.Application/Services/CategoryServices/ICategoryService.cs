using JustBlog.ViewModel.Categories;
using System.Collections.Generic;

namespace JustBlog.Application.Services.CategoryServices
{
    public interface ICategoryService
    {
        IEnumerable<CategoryViewModel> GetAll(bool isDeleted = false);

        bool Create(CreateCategoryVm createCategoryVm);

        bool Update(UpdateCategoryVm updateCategoryVm);

        CategoryViewModel FindById(int id);

        UpdateCategoryVm FinByIdUpdate(int id);

        bool Delete(int id);
    }
}