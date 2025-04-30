using AlexTools.Collections;
using UnityEngine.Tilemaps;

namespace AlexTools.Extensions
{
    public static class TilemapExtensions
    {
        public static Grid2<TTile> ToGrid2<TTile>(
            this Tilemap tilemap, 
            int height = 0,
            Orientation orientation = Orientation.X0Z) 
            where TTile : TileBase
        {
            var rectInt = tilemap.cellBounds.ToRectInt(orientation);
            
            Grid2<TTile> grid = new(rectInt);
            grid.AssignValues(position => tilemap.GetTile<TTile>(position.ToVector3Int(orientation, height)));
            
            return grid;
        }

        public static Grid3<TTile> ToGrid3<TTile>(this Tilemap tilemap) where TTile : TileBase
        {
            var grid = new Grid3<TTile>(tilemap.cellBounds);
            grid.AssignValues(tilemap.GetTile<TTile>);
            return grid;
        }
    }
}