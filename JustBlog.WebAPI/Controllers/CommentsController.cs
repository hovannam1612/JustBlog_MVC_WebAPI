using JustBlog.Application.Services.Comments;
using JustBlog.Common.Helpers;
using JustBlog.ViewModel.Comments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JustBlog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : BaseController
    {
        private readonly ICommentService _commentService;
        private readonly ServiceResult _serviceResult;
        private readonly ILogger<CommentsController> _logger;

        public CommentsController(ICommentService commentService, ILogger<CommentsController> logger)
        {
            _commentService = commentService;
            _logger = logger;
            _serviceResult = new ServiceResult();
        }

        // GET: api/<CommentsController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var categories = _commentService.GetAll();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<CommentsController>/id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                _serviceResult.Data = _commentService.FindById(id);
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

        // GET api/<CommentsController>/id
        [Route("/api/[controller]/GetByPostId/{id}")]
        [HttpGet]
        public IActionResult GetByPostId(int id)
        {
            try
            {
                _serviceResult.Data = _commentService.GetByPostId(id);
                if (_serviceResult.Data == null)
                    _serviceResult.Messeger = Properties.Resource.Msg_NotFound;
                return Ok(_serviceResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }

        // POST api/<CommentsController>
        [HttpPost]
        public IActionResult Post(CreateCommentVm comment)
        {
            try
            {
                _serviceResult.Data = _commentService.Create(comment);
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

        // PUT api/<CommentsController>
        [HttpPut]
        public IActionResult Put(UpdateCommentVm comment)
        {
            try
            {
                _serviceResult.Data = _commentService.Update(comment);
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

        // DELETE api/<CommentsController>/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _serviceResult.Data = _commentService.Delete(id);
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