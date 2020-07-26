using AutoMapper;
using HospitalDataAccess.Models.UserModels;
using HospitalWeb.Models.Auth;

namespace HospitalWeb
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
        }
        
    }
}
