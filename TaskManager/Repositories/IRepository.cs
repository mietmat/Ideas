using System.Linq;
using TaskManager.Models;

namespace TaskManager.Repositories
{
    public interface IRepository<T>: IReadRepository<T>,IWriteRepository<T> 
        where T : class,IEntity
    {
     
    }
}
