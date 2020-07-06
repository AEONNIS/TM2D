using TM2D.Model.Maps;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TM2D.Presentation
{
    public class UI : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private Grid _grid;
        [SerializeField] private Map _map;
        [SerializeField] private InfoPanel _infoPanel;
        [SerializeField] private MapHUD _mapHUD;

        #region Unity
        public void OnPointerClick(PointerEventData eventData)
        {
            Vector3Int gridPosition = _grid.WorldToCell(_mainCamera.ScreenToWorldPoint(Input.mousePosition));
            _mapHUD.BacklightTile(gridPosition);
            PresentTilesInfo(gridPosition);
        }
        #endregion

        private void PresentTilesInfo(Vector3Int gridPosition)
        {
            _infoPanel.PresentTileInfo(gridPosition, LayerName.Background,
                                       _map.GetTileData(LayerName.Background, gridPosition));
            _infoPanel.PresentTileInfo(gridPosition, LayerName.Foreground,
                                       _map.GetTileData(LayerName.Foreground, gridPosition));
        }
    }
}
