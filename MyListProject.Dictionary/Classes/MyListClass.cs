using System.Collections;

namespace MyListProject.Dictionary.Classes
{
    public class MyListClass<T> : IEnumerable<T>
    {
        private IDictionary<int, T> _dataDictionary = new Dictionary<int, T>();

        public MyListClass()
        {

        }
        public int Count()
        {
            return _dataDictionary.Count;
        }

        public IDictionary<int, T> GetAll()
        {
            return _dataDictionary;
        }

        public bool Contains(int key)
        {
            return _dataDictionary.ContainsKey(key);
        }

        public bool Any()
        {
            return Count() > 0;
        }

        public void Add(int key, T newElement)
        {
            _dataDictionary.Add(key, newElement);
        }

        public void Remove(int key)
        {
            _dataDictionary.Remove(key);
        }

        public T GetById(int key)
        {
            return (T)_dataDictionary[key];
        }
        public void Update(int key, T newElement)
        {
            _dataDictionary[key] = newElement;
        }

        public IEnumerator<T> GetEnumerator()
        {
            IEnumerable<T> values = _dataDictionary.Values.OfType<T>();
            return values.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
