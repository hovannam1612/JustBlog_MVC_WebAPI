using JustBlog.Application.Services;
using JustBlog.Common.Helpers;
using JustBlog.ViewModel.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace JustBlog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController
    {
        private readonly IAccountService _userService;
        private readonly ServiceResult _serviceResult;
        private readonly ILogger<AccountsController> _logger;

        public AccountsController(IAccountService userService, ILogger<AccountsController> logger)
        {
            _userService = userService;
            _logger = logger;
            _serviceResult = new ServiceResult();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login(LoginVm loginVm)
        {
            try
            {
                var result = await _userService.GenerateToken(loginVm);
                if (result.Message != null)
                    return Ok(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
            return BadRequest();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register(CreateUserVm createUserVm)
        {
            try
            {
                var result = await _userService.CreateAsync(createUserVm);
                _serviceResult.Data = result.IsSuccessed;
                _serviceResult.Messeger = result.Message;

                if (result.IsSuccessed)
                    return Ok(_serviceResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(_serviceResult);
            }
            return BadRequest(_serviceResult);
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var users = await _userService.GetAll();

                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NoContent();
            }
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var users = await _userService.GetUserById(id);
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var result = await _userService.Delete(id);
                _serviceResult.Data = result.IsSuccessed;
                _serviceResult.Messeger = result.Message;
                if (result.IsSuccessed)
                    return Ok(_serviceResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(_serviceResult);
            }

            return BadRequest(_serviceResult);
        }
    }
}