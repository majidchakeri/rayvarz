using Microsoft.AspNetCore.Identity;

namespace rayverz.Data.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public List<NewsletterUserState> NewsletterUserStates { get; set; }
    }
}
