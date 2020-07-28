using TM2D.ECS;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TM2D.Model.Maps
{
    public class MapLayer : MonoBehaviour
    {
        [SerializeField] private LayerName _name;
        [SerializeField] private Tilemap _tilemap;

        public IEntity GetTileIn(Vector3Int gridPosition)
        {
            TileBase tileBase = _tilemap.GetTile(gridPosition);
            return (tileBase != null && tileBase is IEntity) ? tileBase as IEntity : null;
        }
    }

    public enum LayerName { Background, Foreground }
}
