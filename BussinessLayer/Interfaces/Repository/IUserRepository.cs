using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Datalayer.Entities;

namespace BussinessLayer.Interfaces.Repository
{
    public interface IUserRepository :IBaseRepository<UserEntity>
    {
        Task<UserEntity?> GetEmailAsync(string emil);
    }
}
