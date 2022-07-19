

using TaskManager.Models;

namespace TaskManager.Repositories
{
    public interface IWriteRepository<in T> where T : class, IEntity
    {
        void Add(T task);
        void Update(int taskId, T task);
        void Delete(int taskId);
    }
}
