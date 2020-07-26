using HospitalDataAccess.Models;
using HospitalDataAccess.Models.UserModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalDataAccess
{
    public class HospitalContext : IdentityDbContext<User, Role, string, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Patient> Patients { get; set; }

        public virtual DbSet<PatientData> PatientDatas { get; set; }

        public virtual DbSet<NutritionSupport> NutritionSupports { get; set; }

        public virtual DbSet<Drug> Drugs { get; set; }
    }
}