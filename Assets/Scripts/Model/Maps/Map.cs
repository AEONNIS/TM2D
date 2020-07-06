using TM2D.Model.Tiles;
using UnityEngine;

namespace TM2D.Model.Maps
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private Grid _grid;
        [SerializeField] private MapLayer _background;
        [SerializeField] private MapLayer _foreground;

        public (GameTileData, Sprite) GetTileData(LayerName layerName, Vector3 worldMousePosition)
        {
            return SelectLayer(layerName).GetTileData(_grid.WorldToCell(worldMousePosition));
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
