using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace JustBlog.ViewModel.IdentityResult
{
    public class ErrorResult : IdentityCustomResult
    {
        public ErrorResult(string message)
        {
            Message = message;
            IsSuccessed = false;
        }

        public ErrorResult(IEnumerable<IdentityError> error)
        {
            Errors = error;
            IsSuccessed = false;
        }

        public IEnumerable<IdentityError> Errors { get; set; }
    }
}