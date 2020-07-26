using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace HospitalDataAccess.Models.UserModels
{
    public class Role : IdentityRole
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<RoleClaim> RoleClaims { get; set; }
    }
}