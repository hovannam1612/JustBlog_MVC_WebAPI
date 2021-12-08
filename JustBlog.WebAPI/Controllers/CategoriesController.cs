using JustBlog.Application.Services.CategoryServices;
using JustBlog.Common.Helpers;
using JustBlog.ViewModel.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace JustBlog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly ServiceResult _serviceResult;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(ICategoryService categoryService, ILogger<CategoriesController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
            _serviceResult = new ServiceResult();
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var categories = _categoryService.GetAll();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<CategoriesController>/id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                _serviceResult.Data = _categoryService.FindById(id);
                if (_serviceResult.Data == null)
                    _serviceResult.Messeger = Properties.Resource.Msg_NotFound;
                return Ok(_serviceResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public IActionResult Post(CreateCategoryVm category)
        {
            try
            {
                _serviceResult.Data = _categoryService.Create(category);
                if (!(bool)_serviceResult.Data)
                    _serviceResult.Messeger = Properties.Resource.Msg_NoSuccess;
                else
                    _serviceResult.Messeger = Properties.Resource.Msg_Inserted;

                return Ok(_serviceResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<CategoriesController>
        [HttpPut]
        public IActionResult Put(UpdateCategoryVm category)
        {
            try
            {
                _serviceResult.Data = _categoryService.Update(category);
                if (!(bool)_serviceResult.Data)
                    _serviceResult.Messeger = Properties.Resource.Msg_NoSuccess;
                else
                    _serviceResult.Messeger = Properties.Resource.Msg_Updated;

                return Ok(_serviceResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<CategoriesController>/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _serviceResult.Data = _categoryService.Delete(id);
                if (!(bool)_serviceResult.Data)
                    _serviceResult.Messeger = Properties.Resource.Msg_NoSuccess;
                else
                    _serviceResult.Messeger = Properties.Resource.Msg_Deleted;
                return Ok(_serviceResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}