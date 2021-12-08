using Microsoft.AspNetCore.Identity;

namespace JustBlog.Model.Entities
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }

        public int Age { get; set; }

        public string AvaterUrl { get; set; }

        public string AboutMe { get; set; }
    }
}