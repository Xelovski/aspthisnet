using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Datalayer.Entities;

namespace BussinessLayer.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<List<UserEntity>> GetAll();
        Task<UserEntity?> GetEmailAsync(string emil);
    }
}
