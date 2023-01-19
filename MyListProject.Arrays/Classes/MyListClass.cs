using System.Collections;

namespace MyListProject.Arrays.Classes
{
    public class MyListClass<T>: IEnumerable<T>
    {
        private T[] _dataArray;
        private int _size = 0;
        private int _capacity;

        public MyListClass(int initialCapacity = 10)
        {
            if (initialCapacity < 1) initialCapacity = 1;
            _capacity = initialCapacity;
            _dataArray = new T[initialCapacity];
        }
        public MyListClass(T[] array)
        {
            _dataArray = new T[array.Length];
        }
        public int Count()
        {
            return _size;
        }
        public T[] GetAll()
        {
            if (_size == 0)
                return Array.Empty<T>();
            T[] usedArray = new T[_size];
            for (int i = 0; i < _size; i++)
            {
                usedArray[i] = _dataArray[i];
            }
            return usedArray;
        }

        public T GetById(Predicate<T> predicate)
        {
            int index =  GetIndex(predicate);
            return _dataArray[index];
        }

        public bool Contains(T value)
        {
            return Array.IndexOf(_dataArray, value) > 0;
        }

        public void Sort()
        {
            Array.Sort<T>(_dataArray, 0, _size);
        }

        public  void Sort(IComparer<T> comparer)
        {
           Array.Sort<T>(_dataArray, 0, _size, comparer);
        }

        public bool Any()
        {
            return _size > 0;
        }
        public void Update(Predicate<T> predicate, T newElement)
        {
            int index = GetIndexAndThrowErrorIfNotExistData(predicate);
            UpdateAt(index, newElement);
        }
        public void Remove(Predicate<T> predicate)
        {
            int index = GetIndexAndThrowErrorIfNotExistData(predicate);
            RemoveAt(index);
        }

        #region Work with indexs
        public T GetAt(int index)
        {
            ThrowIfIndexOutOfRange(index);
            return _dataArray[index];
        }
        public void RemoveAt(int index)
        {
            ThrowIfIndexOutOfRange(index);

            for (int currentIndex = index; currentIndex < _size - 1; currentIndex++)
            {
                _dataArray[currentIndex] = _dataArray[currentIndex + 1];
            }
            _dataArray[_size - 1] = default;
            _size--;
        }
        public void UpdateAt(int index, T newElement)
        {
            ThrowIfIndexOutOfRange(index);
            _dataArray[index] = newElement;
        }
        #endregion
        public void Add(T newElement)
        {
            CheckSizeAndResizeIfNecessary();
            _dataArray[_size] = newElement;
            _size++;
        }

        #region Private methods
        private void Resize()
        {
            int newCapacity = _capacity * 2;
            Array.Resize(ref _dataArray, newCapacity);
            _capacity = newCapacity;
        }
        private void ThrowIfIndexOutOfRange(int index)
        {
            if (index > _size - 1 || index < 0)
            {
                throw new ArgumentOutOfRangeException($"The current size of the array is {_size}");
            }
        }
        private void CheckSizeAndResizeIfNecessary()
        {
            if (_size == _capacity)
            {
                Resize();
            }
        }
        private int GetIndexAndThrowErrorIfNotExistData(Predicate<T> predicate)
        {
            int index = GetIndex(predicate);
            if (index < 0)
                throw new Exception($"Invalid predicate or don't e exist data");
            return index;
        }
        private int GetIndex(Predicate<T> predicate)
        {
            return Array.FindIndex(_dataArray, predicate);
        }
        #endregion
        #region Implementation IEnumerable
        public IEnumerator<T> GetEnumerator()
        {
            var newArray = GetAll();
            IEnumerable<T> values = newArray;
            return values.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
