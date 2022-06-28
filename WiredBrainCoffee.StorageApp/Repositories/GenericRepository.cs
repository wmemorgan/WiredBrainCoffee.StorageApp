using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repositories
{
    public class GenericRepositoryWithRemove<T>
    {
        protected readonly List<T> _items = new();

        public void Add(T item) => _items.Add(item);

        public void Save()
        {
            foreach (T item in _items)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class GenericRepositoryWithRemove<T> : GenericRepositoryWithRemove<T>
    {
        public void Remove(T item) => _items.Remove(item);
    }
}
