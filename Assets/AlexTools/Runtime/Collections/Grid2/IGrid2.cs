using UnityEngine;

namespace AlexTools.Collections
{
    public interface IGrid2<T> :  IReadOnlyGrid2<T>
    {
        new T this[int index] { set; }

        new T this[int x, int y] { set; }
        new T this[Vector2Int position] { set; }
    }
}