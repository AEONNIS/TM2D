using TM2D.ECS;
using UnityEngine;

namespace TM2D.Model.Maps
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private MapLayer _background;
        [SerializeField] private MapLayer _foreground;

        public IEntity GetTileEntityIn(LayerName layer, Vector3Int gridposition)
        {
            return SelectLayer(layer).GetTileIn(gridposition);
        }

        private MapLayer SelectLayer(LayerName layerName) => layerName == LayerName.Background ? _background : _foreground;
    }
}
