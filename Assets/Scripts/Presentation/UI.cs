using TM2D.Model.Maps;
using UnityEngine;

namespace TM2D.Presentation
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private Map _map;
        [SerializeField] private InfoPanel _infoPanel;

        public void PresentTilesInfo(Vector3Int gridPosition)
        {
            //_infoPanel.PresentTileInfo(gridPosition, LayerName.Background,
            //                           _map.GetTileData(LayerName.Background, gridPosition));
            //_infoPanel.PresentTileInfo(gridPosition, LayerName.Foreground,
            //                           _map.GetTileData(LayerName.Foreground, gridPosition));
        }
    }
}
