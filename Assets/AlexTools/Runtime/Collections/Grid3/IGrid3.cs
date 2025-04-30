using UnityEngine;

namespace AlexTools.Collections
{
    public interface IGrid3<T> : IReadOnlyGrid3<T>
    {
        new T this[int index] { get; set; }
        
        new T this[int x, int y, int z] { get; set; }
        new T this[Vector3Int position] { get; set; }
    }
}