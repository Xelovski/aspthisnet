using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Interfaces.Services;
using Common.DTO;
using WebApplication2.Datalayer;

namespace BussinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(UserDTO model)//
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(Guid publicId)//async
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserDTO>> GetAllAsync()//async
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> GetByPublicIIdAsync(Guid publicId)//async
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(UserDTO model)//async
        {
            throw new NotImplementedException();
        }
    }
}
