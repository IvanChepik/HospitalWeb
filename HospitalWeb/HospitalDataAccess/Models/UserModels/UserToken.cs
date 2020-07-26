using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace HospitalDataAccess.Models.UserModels
{
    public class UserToken : IdentityUserToken<string>
    {
        [Key]
        public int UserTokenId { get; set; }
        public virtual User User { get; set; }
    }
}