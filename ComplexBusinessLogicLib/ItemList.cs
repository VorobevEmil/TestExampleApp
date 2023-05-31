namespace ComplexBusinessLogicLib
{
    public class ItemList<T>
    {
        private readonly Dictionary<int, T> _items = new();
        private int _indentifier = 0;

        public int Count => _items.Count;
        public IEnumerable<T> All => _items.Values;

        public T this[int index]
        {
            get => _items[index];
        }

        public void Add(T item)
        {
            _items.Add(++_indentifier, item);
        }

        public void Remove(T item)
        {
            var findItem = _items.First(x => x.Value?.Equals(item) ?? false).Key;

            _items.Remove(findItem);
        }

        public void RemoveById(int id)
        {
            var itemKey = _items.First(x => x.Key == id).Key;

            _items.Remove(itemKey);
        }

        public List<int> GetAllIndex()
        {
            return _items.Keys.ToList();
        }

        public bool ContainValue(T item)
        {
            return _items.ContainsValue(item);
        }
    }
}