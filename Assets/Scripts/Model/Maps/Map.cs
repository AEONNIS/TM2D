using TM2D.Model.Tiles;
using UnityEngine;

namespace TM2D.Model.Maps
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private MapLayer _background;
        [SerializeField] private MapLayer _foreground;

        public (GameTileData, Sprite) GetTileData(LayerName layerName, Vector3Int gridPosition)
        {
            return SelectLayer(layerName).GetTileData(gridPosition);
        }

        private MapLayer SelectLayer(LayerName layerName)
        {
            if (layerName == LayerName.Background)
                return _background;
            else
                return _foreground;
        }
    }
}
