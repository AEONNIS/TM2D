using TM2D.ECS;
using UnityEngine;

namespace TM2D.Model.Maps
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private MapLayer _background;
        [SerializeField] private MapLayer _foreground;

        public IEntity GetEntityIn(LayerName layer, Vector3Int gridposition) => SelectLayer(layer).GetEntityIn(gridposition);

        public (IEntity, Sprite) GetTileIn(LayerName layer, Vector3Int gridposition) => SelectLayer(layer).GetTileIn(gridposition);

        private MapLayer SelectLayer(LayerName layerName) => layerName == LayerName.Background ? _background : _foreground;
    }
}
