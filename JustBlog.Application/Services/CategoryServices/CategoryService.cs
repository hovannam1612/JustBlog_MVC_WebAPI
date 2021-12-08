using AutoMapper;
using JustBlog.Infrastructure.Infrastructures;
using JustBlog.Model.Entities;
using JustBlog.ViewModel.Categories;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace JustBlog.Application.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool Create(CreateCategoryVm createCategoryVm)
        {
            var category = _mapper.Map<Category>(createCategoryVm);
            _unitOfWork.CategoryRepository.Add(category);
            return _unitOfWork.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            _unitOfWork.CategoryRepository.Delete(id, true);
            return _unitOfWork.SaveChanges() > 0;
        }

        public UpdateCategoryVm FinByIdUpdate(int id)
        {
            var category = _unitOfWork.CategoryRepository.GetById(id);
            return _mapper.Map<UpdateCategoryVm>(category);
        }

        public CategoryViewModel FindById(int id)
        {
            var category = _unitOfWork.CategoryRepository.GetById(id);
            return _mapper.Map<CategoryViewModel>(category);
        }

        public IEnumerable<CategoryViewModel> GetAll(bool isDeleted = false)
        {
            var categories = _unitOfWork.CategoryRepository.GetAll(isDeleted);
            return _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
        }

        public bool Update(UpdateCategoryVm updateCategoryVm)
        {
            var categoryExist = _unitOfWork.CategoryRepository.GetById(updateCategoryVm.Id);
            if (categoryExist != null)
            {
                categoryExist.Name = updateCategoryVm.Name;
                categoryExist.UrlSlug = updateCategoryVm.UrlSlug;
                categoryExist.Description = updateCategoryVm.Description;

                _unitOfWork.CategoryRepository.Update(categoryExist);
            }
            return _unitOfWork.SaveChanges() > 0;
        }
    }
}