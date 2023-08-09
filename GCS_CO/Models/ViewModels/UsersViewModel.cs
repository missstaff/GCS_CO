using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace GCS_CO.Models.ViewModels
{
    public class UsersVM
    {
        public IEnumerable<AppUser> Users { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}