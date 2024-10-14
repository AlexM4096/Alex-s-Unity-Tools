using AlexTools.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace AlexTools.Extensions
{
    public static class TilemapExtensions
    {
        public static Grid2<TTile> ToGrid2<TTile>(
            this Tilemap tilemap, 
            int height = 0,
            Orientation orientation = Orientation.X0Y) 
            where TTile : TileBase
        {
            RectInt rectInt = tilemap.cellBounds.ToRectInt(orientation);
            
            Grid2<TTile> grid = new(rectInt);
            grid.AssignValues(position => 
                tilemap.GetTile<TTile>(position.ToVector3Int(orientation, height)));
            
            return grid;
        }

        public static Grid3<TTile> ToGrid3<TTile>(
            this Tilemap tilemap) 
            where TTile : TileBase
        {
            Grid3<TTile> grid = new(tilemap.cellBounds);
            grid.AssignValues(tilemap.GetTile<TTile>);
            
            return grid;
        }
    }
}