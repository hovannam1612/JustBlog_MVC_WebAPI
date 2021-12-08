using System.Collections.Generic;

namespace JustBlog.ViewModel.Accounts
{
    public class UserVm
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public IList<string> RoleNames { get; set; }
    }
}