using TM2D.Model.Maps;
using UnityEngine;

namespace TM2D.Presentation
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private Grid _grid;
        [SerializeField] private InfoPanel _infoPanel;
        [SerializeField] private Map _map;
        [SerializeField] private MapHUD _mapHUD;

        #region Unity
        private void Update()
        {
            Vector3Int gridPosition = _grid.WorldToCell(_mainCamera.ScreenToWorldPoint(Input.mousePosition));
            PresentTileInfo(gridPosition);
            _mapHUD.BacklightTile(gridPosition);
        }
        #endregion

        private void PresentTileInfo(Vector3Int gridPosition)
        {
            _infoPanel.PresentTileInfo(gridPosition, LayerName.Background,
                                       _map.GetTileData(LayerName.Background, gridPosition));
            _infoPanel.PresentTileInfo(gridPosition, LayerName.Foreground,
                                       _map.GetTileData(LayerName.Foreground, gridPosition));
        }
    }
}
