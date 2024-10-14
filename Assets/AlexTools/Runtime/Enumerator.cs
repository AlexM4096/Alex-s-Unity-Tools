using System.Collections;
using System.Collections.Generic;

namespace AlexTools
{
    public struct Enumerator : IEnumerator
    {
        private readonly IList _list;

        private object _current;
        private int _index;

        public Enumerator(IList list) : this()
        {
            _list = list;
        }

        public object Current => _current;

        public bool MoveNext()
        {
            if (_index < _list.Count)
            {
                _current = _list[_index];
                _index++;
                return true;
            }
            else
            {
                _current = default;
                return false;
            }
        }

        public void Reset()
        {

        }
    }

    public struct Enumerator<T> : IEnumerator<T>
    {
        private readonly IList<T> _list;

        private T _current;
        private int _index;

        public Enumerator(IList<T> list) : this()
        {
            _list = list;
        }

        public T Current => _current;
        object IEnumerator.Current => _current;


        public bool MoveNext()
        {
            if (_index < _list.Count)
            {
                _current = _list[_index];
                _index++;
                return true;
            }
            else
            {
                _current = default;
                return false;
            }
        }

        public void Reset()
        {

        }

        public void Dispose()
        {

        }
    }
}