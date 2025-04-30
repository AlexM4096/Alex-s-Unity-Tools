using System.Collections;
using System.Collections.Generic;

namespace AlexTools
{
    public interface ICycleEnumerator : IEnumerator
    {
        int Index { get; set; }
        bool MovePrevious();
    }
    
    public interface ICycleEnumerator<out T> : ICycleEnumerator, IEnumerator<T>
    {

    }
    
    public class CycleEnumerator : ICycleEnumerator
    {
        private readonly IList _list;
        
        public readonly IEnumerator Forward;
        public readonly IEnumerator Reverse;

        private object _current;
        public object Current => _current;
        
        private int _index;
        public int Index
        {
            get => _index;
            set
            {
                _index = (value + _list.Count) % _list.Count;
                _current = _list[Index];
            }
        }
        
        public CycleEnumerator(IList list)
        {
            _list = list;

            Forward = new ForwardEnumerator(this);
            Reverse = new ReverseEnumerator(this);
        }

        public bool MoveNext() => Forward.MoveNext();
        public bool MovePrevious() => Reverse.MoveNext();

        public void Reset() => Index = 0;

        private readonly struct ForwardEnumerator : IEnumerator
        {
            private readonly ICycleEnumerator _parent;

            public ForwardEnumerator(ICycleEnumerator parent) => _parent = parent;

            public bool MoveNext()
            {
                _parent.Index++;
                return true;
            }

            public void Reset() => _parent.Reset();
            
            public object Current => _parent.Current;
        }
        
        private readonly struct ReverseEnumerator : IEnumerator
        {
            private readonly ICycleEnumerator _parent;

            public ReverseEnumerator(ICycleEnumerator parent) => _parent = parent;

            public bool MoveNext()
            {
                _parent.Index--;
                return true;
            }

            public void Reset() => _parent.Reset();
            
            public object Current => _parent.Current;
        }
    }
    
    public class CycleEnumerator<T> : ICycleEnumerator<T>
    {
        private readonly IList<T> _list;
        
        public readonly IEnumerator<T> Forward;
        public readonly IEnumerator<T> Reverse;

        private T _current;
        public T Current => _current;
        object IEnumerator.Current => _current;
        
        private int _index;
        public int Index
        {
            get => _index;
            set
            {
                _index = (value + _list.Count) % _list.Count;
                _current = _list[Index];
            }
        }
        
        public CycleEnumerator(IList<T> list)
        {
            _list = list;

            Forward = new ForwardEnumerator(this);
            Reverse = new ReverseEnumerator(this);
        }

        public bool MoveNext() => Forward.MoveNext();
        public bool MovePrevious() => Reverse.MoveNext();

        public void Reset() => Index = 0;

        public void Dispose()
        {
            Forward.Dispose();
            Reverse.Dispose();
        }

        private readonly struct ForwardEnumerator : IEnumerator<T>
        {
            private readonly ICycleEnumerator<T> _parent;

            public ForwardEnumerator(ICycleEnumerator<T> parent) => _parent = parent;

            public bool MoveNext()
            {
                _parent.Index++;
                return true;
            }

            public void Reset() => _parent.Reset();

            public T Current => _parent.Current;
            object IEnumerator.Current => _parent.Current;

            public void Dispose() { }
        }
        
        private readonly struct ReverseEnumerator : IEnumerator<T>
        {
            private readonly ICycleEnumerator<T> _parent;

            public ReverseEnumerator(ICycleEnumerator<T> parent) => _parent = parent;

            public bool MoveNext()
            {
                _parent.Index--;
                return true;
            }

            public void Reset() => _parent.Reset();

            public T Current => _parent.Current;
            object IEnumerator.Current => _parent.Current;

            public void Dispose() { }
        }
    }
}