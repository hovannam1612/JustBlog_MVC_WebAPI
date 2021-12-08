using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JustBlog.WebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class BaseController : Controller
    {
        
    }
}