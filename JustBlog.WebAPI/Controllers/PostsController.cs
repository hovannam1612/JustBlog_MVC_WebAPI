using JustBlog.Application.Services.PostServices;
using JustBlog.Common.Constraints;
using JustBlog.Common.Helpers;
using JustBlog.Model.Entities;
using JustBlog.ViewModel.BaseEntity;
using JustBlog.ViewModel.Posts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace JustBlog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : BaseController
    {
        private readonly IPostService _postService;
        private readonly ServiceResult _serviceResult;
        private readonly ILogger<PostsController> _logger;

        public PostsController(IPostService postService, ILogger<PostsController> logger)
        {
            _postService = postService;
            _logger = logger;
            _serviceResult = new ServiceResult();
        }

        // GET: api/<PostsController>
        [HttpGet]
        public IActionResult Get([FromQuery] FilterPaging filterPaging)
        {
            try
            {
                filterPaging.SearchBy = filterPaging.SearchBy == null ? Searching.CreatedOn : filterPaging.SearchBy;

                Func<Post, bool> filter = null;
                if (!string.IsNullOrEmpty(filterPaging.Keyword))
                {
                    filterPaging.Keyword = filterPaging.Keyword.ToLower();
                    if (filterPaging.SearchBy == Searching.Title)
                        filter = x => x.Title.ToLower().Contains(filterPaging.Keyword);
                    else
                        filter = x => x.PostContent.ToLower().Contains(filterPaging.Keyword);
                }
                var postPaged = _postService.GetPaging(filter: filter, searchBy: filterPaging.SearchBy,
                                                    pageIndex: filterPaging.PageIndex, pageSize: filterPaging.PageSize,
                                                    typeOfSoft: filterPaging.TypeOfSoft);
                return Ok(postPaged);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<PostsController>/id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                _serviceResult.Data = _postService.FindById(id);
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

        // POST api/<PostsController>
        [HttpPost]
        public IActionResult Post(CreatePostVm post)
        {
            try
            {
                _serviceResult.Data = _postService.Create(post);
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

        // PUT api/<PostsController>
        [HttpPut]
        public IActionResult Put(UpdatePostVm post)
        {
            try
            {
                _serviceResult.Data = _postService.Update(post);
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

        // DELETE api/<PostsController>/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _serviceResult.Data = _postService.Delete(id);
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