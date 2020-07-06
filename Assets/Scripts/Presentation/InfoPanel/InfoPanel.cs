using TM2D.Model.Maps;
using TM2D.Model.Tiles;
using UnityEngine;

namespace TM2D.Presentation
{
    public class InfoPanel : MonoBehaviour
    {
        [SerializeField] private Transform _content;
        [SerializeField] private TileInfo _tileInfoTemplate;

        private TileInfo _backround;
        private TileInfo _foreground;

        #region Unity
        private void Start()
        {
            InstantiatePanel(out _backround, LayerName.Background);
            InstantiatePanel(out _foreground, LayerName.Foreground);
        }
        #endregion

        public void PresentTileInfo(LayerName mapLayerName, (GameTileData data, Sprite sprite) tile)
        {
            if (mapLayerName == LayerName.Background)
                _backround.Present(tile);
            else
                _foreground.Present(tile);
        }

        private void InstantiatePanel(out TileInfo tileInfo, LayerName mapLayerName)
        {
            tileInfo = Instantiate(_tileInfoTemplate, _content);
            tileInfo.Init(mapLayerName);
        }
    }
}
