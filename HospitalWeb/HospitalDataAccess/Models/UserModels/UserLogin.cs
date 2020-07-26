using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace HospitalDataAccess.Models.UserModels
{
    public class UserLogin : IdentityUserLogin<string>
    {
        [Key]
        public int UserLoginId { get; set; }
        public virtual User User { get; set; }
    }
}