using TM2D.Model.Tiles;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TM2D.Model.Maps
{
    public class MapLayer : MonoBehaviour
    {
        [SerializeField] private LayerName _name;
        [SerializeField] private Tilemap _tilemap;

        public (GameTileData, Sprite) GetTileData(Vector3Int gridPosition)
        {
            TileBase tileBase = _tilemap.GetTile(gridPosition);

            if (tileBase != null && tileBase is IGameTile gameTile)
                return (gameTile.TileData, _tilemap.GetSprite(gridPosition));
            else
                return (null, null);
        }
    }

    public enum LayerName { Background, Foreground }
}
