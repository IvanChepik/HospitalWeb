using AutoMapper;
using HospitalDataAccess;
using HospitalDataAccess.Models.UserModels;
using HospitalWeb.Models.Auth;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HospitalWeb.Services
{
    public class UserService<TUser> where TUser : User, new()
    {
        private readonly HospitalContext _context;
        private readonly IMapper _mapper;

        public UserService(HospitalContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetById(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<UserDTO>(user);
        }

    }
}
