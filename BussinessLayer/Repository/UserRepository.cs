using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Interfaces.Repository;
using WebApplication2.Datalayer;
using WebApplication2.Datalayer.Entities;

namespace BussinessLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public Task<List<UserEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity?> GetEmailAsync(string emil)
        {
            throw new NotImplementedException();
        }
    }
}
