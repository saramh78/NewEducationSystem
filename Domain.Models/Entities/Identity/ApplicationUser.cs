using Microsoft.AspNetCore.Identity;


namespace Domain.Models.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
        }

        public ApplicationUser(string userName) : base(userName)
        {
        }
    }
}
