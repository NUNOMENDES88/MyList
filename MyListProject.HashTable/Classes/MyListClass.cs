using System.Collections;

namespace MyListProject.HashTable.Classes
{
    public class MyListClass<T> : IEnumerable<T>
    {
         private Hashtable _dataHashtable = new();
        public MyListClass()
        {

        }
        public int Count()
        {
            return _dataHashtable.Count;
        }

        public Hashtable GetAll()
        {
            return _dataHashtable;
        }

        public bool Contains(int key)
        {
            return _dataHashtable.ContainsKey(key);
        }

        public bool Any()
        {
            return Count() > 0;
        }

        public void Add(int key, T newElement)
        {
            _dataHashtable.Add(key, newElement);
        }

        public void Remove(int key)
        {
            _dataHashtable.Remove(key);
        }

        public T GetById(int key)
        {
            return (T)_dataHashtable[key];
        }
        public void Update(int key, T newElement)
        {
            _dataHashtable[key] = newElement;
        }

        public IEnumerator<T> GetEnumerator()
        {
            IEnumerable<T> values = _dataHashtable.Values.OfType<T>();
            return values.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
