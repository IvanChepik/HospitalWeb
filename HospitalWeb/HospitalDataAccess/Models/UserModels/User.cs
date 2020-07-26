using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace HospitalDataAccess.Models.UserModels
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public void Include(object x)
        {
            throw new NotImplementedException();
        }

        public DateTime DateCreated { get; set; } = DateTime.Now;
        public virtual ICollection<UserClaim> Claims { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}