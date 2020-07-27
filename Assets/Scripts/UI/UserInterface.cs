using TM2D.ECS;
using TM2D.Model.Maps;
using UnityEngine;

namespace TM2D.UI
{
    public class UserInterface : MonoBehaviour
    {
        [SerializeField] private Map _map;
        [SerializeField] private InfoPanel _infoPanel;

        public void PresentTilesInfo(Vector3Int gridPosition)
        {
            //_infoPanel.PresentTileInfo(gridPosition, LayerName.Background,
            //                           _map.GetTileData(LayerName.Background, gridPosition));
            //_infoPanel.PresentTileInfo(gridPosition, LayerName.Foreground,
            //                           _map.GetTileData(LayerName.Foreground, gridPosition));

            IEntity entity = _map.GetTileIn(LayerName.Background, gridPosition);
            _infoPanel.Present(entity);
        }
    }
}
