
using System.Collections.Generic;
using System.Linq;
using TaskManager.Models;

namespace TaskManager.Repositories
{
    public interface IReadRepository<out T> where T : class, IEntity
    {
        T Get(int taskId);
        IQueryable<T> GetAllActive();
    }
}
