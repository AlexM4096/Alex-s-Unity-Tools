using System.Collections;
using System.Collections.Generic;

namespace AlexTools.Enumerators
{
    public class Enumerator : IEnumerator
    {
        private readonly IList _list;
    
        private object _current;
        private int _index;
    
        public object Current => _current;
        
        public Enumerator(IList list) => _list = list;
    
        public bool MoveNext()
        {
            if (_index < _list.Count)
            {
                _current = _list[_index];
                _index++;
                return true;
            }

            _current = default;
            return false;
        }
    
        public void Reset()
        {
    
        }
    }

    public class Enumerator<T> : IEnumerator<T>
    {
        private readonly IList<T> _list;

        private T _current;
        private int _index;

        public T Current => _current;
        object IEnumerator.Current => _current;
        
        public Enumerator(IList<T> list) => _list = list;

        public bool MoveNext()
        {
            if (_index < _list.Count)
            {
                _current = _list[_index];
                _index++;
                return true;
            }

            _current = default;
            return false;
        }

        public void Reset()
        {

        }

        public void Dispose()
        {

        }
    }
}