using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Interfaces.Services;
using Common.DTO;
using Microsoft.EntityFrameworkCore;
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
            /*
            var us =  _context.Users.FirstOrDefaultAsync(u => u.PublicId == publicId);
            if (us != null)
            {
                await _context.Users.Remove(us);
                await _context.SaveChangesAsync();
            }
            //throw new NotImplementedException();*/
            return true;
        }

        public async Task<List<UserDTO>> GetAllAsync()//async
        {
            var userList=await _context.Users.ToListAsync();
            var userListDTO=new List<UserDTO>();
            foreach (var user in userList)
            {
                var userDTO = new UserDTO()
                {
                    Id =user.Id,
                    PublicId = user.PublicId,
                    Name = user.Name,
                    Emil = user.Email
                };
                userListDTO.Add(userDTO);
            }
            return userListDTO;
            //throw new NotImplementedException();
        }

        public async Task<UserDTO> GetByPublicIIdAsync(Guid publicId)//async
        {

            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(UserDTO model)//async
        {

            return true;
        }
    }
}
