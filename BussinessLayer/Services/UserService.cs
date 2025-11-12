using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Interfaces.Services;
using Common.DTO;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Datalayer;
using WebApplication2.Datalayer.Entities;

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
            var a = new UserEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Emil,
                PublicId = model.PublicId,
            };
            await _context.Users.AddAsync(a);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid publicId)//async
        {
            var us = await _context.Users.ToListAsync();
            foreach (UserEntity? i in us)
            {
                if (publicId == i.PublicId)
                {
                    var a = new UserEntity()
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Email = i.Email,
                        PublicId = i.PublicId,
                    };
                    if (a != null)
                    {
                        _context.Users.Remove(a);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            return true;
        }

        public async Task<List<UserDTO>> GetAllAsync()//async
        {
            var userList=await _context.Users.ToListAsync();
            var userListDTO=new List<UserDTO>();
            foreach (UserEntity? user in userList)
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
            var userDTO = new UserDTO();
            var us = await _context.Users.ToListAsync();
            foreach (UserEntity? i in us)
            {
                if (publicId == i.PublicId)
                { 
                    userDTO= new UserDTO()
                    {
                        Id = i.Id,
                        PublicId = i.PublicId,
                        Name = i.Name,
                        Emil = i.Email
                    };
                }
            }
            return userDTO;
        }

        public async Task<bool> UpdateAsync(UserDTO model)//async
        {
            var a = new UserEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Emil,
                PublicId = model.PublicId,
            };
            var us = await _context.Users.ToListAsync();
            if (a != null)
            {
                foreach (UserEntity? i in us)                
                {
                    if (a.PublicId == i.PublicId)
                    {
                        _context.Users.Remove(i);
                        await _context.SaveChangesAsync();
                        await _context.Users.AddAsync(a);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            return true;

        }
    }
}
