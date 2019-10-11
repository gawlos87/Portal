using System.Threading.Tasks;

namespace Portal.Api.Data
{
    public interface IGenericRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
    }
}