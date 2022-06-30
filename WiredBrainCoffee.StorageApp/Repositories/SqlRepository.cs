using Microsoft.EntityFrameworkCore;
using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repositories
{
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbContext _dBContext;
        private readonly Action<T>? _itemAddedCallback;
        private readonly DbSet<T> _dbSet;

        public SqlRepository(DbContext dbContext, Action<T>? itemAddedCallback = null)
        {
            _dBContext = dbContext;
            _itemAddedCallback = itemAddedCallback;
            _dbSet = _dBContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.OrderBy(item => item.Id).ToList();
        }

        public T GetById(int id) => _dbSet.Find(id);


        public void Add(T item)
        {
            _dbSet.Add(item);
            _itemAddedCallback?.Invoke(item);
        }

        public void Remove(T item) => _dbSet.Remove(item);

        public void Save()
        {
            _dBContext.SaveChanges();
        }
    }
}
