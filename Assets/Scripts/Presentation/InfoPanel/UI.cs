using TM2D.Model.Maps;
using UnityEngine;

namespace TM2D.Presentation
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private InfoPanel _infoPanel;
        [SerializeField] private Map _map;

        #region Unity
        private void Update()
        {
            PresentTileInfo();
        }
        #endregion

        private void PresentTileInfo()
        {
            Vector3 worldMousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            _infoPanel.PresentTileInfo(LayerName.Background,
                                       _map.GetTileData(LayerName.Background, worldMousePosition));
            _infoPanel.PresentTileInfo(LayerName.Foreground,
                                       _map.GetTileData(LayerName.Foreground, worldMousePosition));
        }
    }
}
