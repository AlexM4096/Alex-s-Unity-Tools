using AlexTools.Collections;
using AlexTools.Enums;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace AlexTools.Extensions
{
    public static class TilemapExtensions
    {
        public static IGrid2<TTile> ToGrid2<TTile>(
            this Tilemap tilemap, 
            int height = 0,
            Orientation orientation = Orientation.X0Y)
            where TTile : TileBase
        {
            RectInt rectInt = tilemap.cellBounds.ToRectInt(orientation);
            
            IGrid2<TTile> grid2 = new Grid2<TTile>(rectInt);
            grid2.AssignValues(position => 
                tilemap.GetTile<TTile>(position.ToVector3Int(orientation, height)));
            
            return grid2;
        }
        
        public static IGrid3<TTile> ToGrid3<TTile>(
            this Tilemap tilemap) 
            where TTile : TileBase
        {
            IGrid3<TTile> grid3 = new Grid3<TTile>(tilemap.cellBounds);
            grid3.AssignValues(tilemap.GetTile<TTile>);
            
            return grid3;
        }
    }
}