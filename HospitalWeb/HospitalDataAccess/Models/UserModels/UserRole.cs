using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace HospitalDataAccess.Models.UserModels
{
    public class UserRole : IdentityUserRole<string>
    {
        [Key]
        public int UserRoleId { get; set; }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}