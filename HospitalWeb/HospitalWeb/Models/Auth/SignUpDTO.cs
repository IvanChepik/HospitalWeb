namespace HospitalWeb.Models.Auth
{
    public class SignUpDTO : LoginDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string ConfirmPassword { get; set; }
    }
}