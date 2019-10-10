using System.Collections.Generic;
using System.Threading.Tasks;
using Portal.Api.Models;

namespace Portal.Api.Data
{
    public interface IUserRepository : IGenericRepository
    {
         Task<IEnumerable<User>> GetUsers();
         Task<User> GetUser (int id);
    }
}