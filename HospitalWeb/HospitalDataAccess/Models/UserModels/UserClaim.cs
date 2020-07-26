using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace HospitalDataAccess.Models.UserModels
{
    public class UserClaim : IdentityUserClaim<string>
    {
        [Key]
        public int UserClaimId { get; set; }
        public virtual User User { get; set; }
    }
}