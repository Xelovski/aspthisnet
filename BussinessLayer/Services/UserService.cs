using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Interfaces.Repository;
using BussinessLayer.Interfaces.Services;
using Common.DTO;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Datalayer;
using WebApplication2.Datalayer.Entities;

namespace BussinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository r)
        {
            _userRepository = r;
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
            await _userRepository.CreateAsync(a);
            await _userRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid publicId)//async
        {
            var us = await _userRepository.GetAllAsync();
            var user = await _userRepository.GetByPublicIdAsync(publicId); 
            if (user == null) { return false; } 
            _userRepository.Delete(user);
            await _userRepository.SaveChangesAsync();
            return true;
            /*
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
                        //_context.Users.ExecuteDeleteAsync
                        _context.SaveChanges();
                    }
                }
            }
            return true;*/
        }

        public async Task<List<UserDTO>> GetAllAsync()//async
        {
            var userList=await _userRepository.GetAllAsync();
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
        }
        public async Task<List<Guid>> GetAllPublicIdAsync()//async
        {
            var userList = await _userRepository.GetAllAsync();
            var userListDTO = new List<Guid>();
            foreach (UserEntity? user in userList)
            {
                userListDTO.Add(user.PublicId);
            }
            return userListDTO;
        }

        public async Task<UserDTO> GetByPublicIIdAsync(Guid publicId)//async
        {
            var userDTO = new UserDTO();
            var us = await _userRepository.GetAllAsync();
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
            var user = await _userRepository.GetByPublicIdAsync(model.PublicId);
            if (user == null) { return false; }
            _userRepository.Delete(user);
            await _userRepository.SaveChangesAsync();
            var us = await _userRepository.GetAllAsync();
            await _userRepository.CreateAsync(a);
            await _userRepository.SaveChangesAsync();
            return true;

        }
    }
}
