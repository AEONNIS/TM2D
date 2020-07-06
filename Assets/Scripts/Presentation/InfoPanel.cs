using TM2D.Model.Maps;
using TM2D.Model.Tiles;
using UnityEngine;
using UnityEngine.UI;

namespace TM2D.Presentation
{
    public class InfoPanel : MonoBehaviour
    {
        [SerializeField] private Transform _content;
        [SerializeField] private TileInfo _tileInfoTemplate;
        [SerializeField] private Text _gridPosition;

        private TileInfo _backround;
        private TileInfo _foreground;

        #region Unity
        private void Start()
        {
            InstantiatePanel(out _backround, LayerName.Background);
            InstantiatePanel(out _foreground, LayerName.Foreground);
        }
        #endregion

        public void PresentTileInfo(Vector3Int gridPosition, LayerName mapLayerName, (GameTileData data, Sprite sprite) tile)
        {
            _gridPosition.text = ((Vector2Int)gridPosition).ToString();

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
