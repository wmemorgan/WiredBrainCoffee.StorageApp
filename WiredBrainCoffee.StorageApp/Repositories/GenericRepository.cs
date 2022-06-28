using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repositories
{
    public class GenericRepository<T> where T : class, IEntity, new() //must be last constraint declared
    {
        private readonly List<T> _items = new();

        public T? GetById(int id) => _items.Single(item => item.Id == id);

        public T CreateItem() => new T();

        public void Add(T item)
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
        }

        public void Remove(T item) => _items.Remove(item);

        public void Save()
        {
            foreach (T item in _items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
