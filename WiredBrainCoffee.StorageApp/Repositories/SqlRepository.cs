using Microsoft.EntityFrameworkCore;
using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repositories
{
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbContext _dBContext;
        private readonly DbSet<T> _dbSet;

        public SqlRepository(DbContext dbContext)
        {
            _dBContext = dbContext;
            _dbSet = _dBContext.Set<T>();
        }

        public event EventHandler<T>? ItemAdded;

        public IEnumerable<T> GetAll()
        {
            return _dbSet.OrderBy(item => item.Id).ToList();
        }

        public T GetById(int id) => _dbSet.Find(id);


        public void Add(T item)
        {
            _dbSet.Add(item);
            ItemAdded?.Invoke(this, item);
        }

        public void Remove(T item) => _dbSet.Remove(item);

        public void Save()
        {
            _dBContext.SaveChanges();
        }
    }
}
