using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repositories
{

    public interface IWriteRepository<in T>
    {
        void Add(T item);
        void Remove(T item);
        void Save();
    }

    public interface IReadRepository<out T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
    }

    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> 
        where T : IEntity
    {

    }

    public class GenericSuperRepository<T> : IRepository<T> where T : IEntity
    {
        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}