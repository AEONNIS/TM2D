using TM2D.Model.Maps;
using TM2D.Model.Tiles;
using UnityEngine;

namespace TM2D.Presentation.InfoPanel
{
    public class InfoPanel : MonoBehaviour
    {
        private const string _floorLayerName = "Слой пола";
        private const string _wallsLayerName = "Слой стен";

        [SerializeField] private Transform _content;
        [SerializeField] private TileInfo _tileInfoTemplate;

        private TileInfo _floorTileInfo;
        private TileInfo _wallsTileInfo;

        #region Unity
        private void Start()
        {
            InstantiatePanel(out _floorTileInfo, _floorLayerName);
            InstantiatePanel(out _wallsTileInfo, _wallsLayerName);
        }
        #endregion

        public void PresentTileInfo(LayerType layerType, GameTileData tileData)
        {
            if (layerType == LayerType.Floor)
                _floorTileInfo.Present(tileData);
            else
                _wallsTileInfo.Present(tileData);
        }

        private void InstantiatePanel(out TileInfo tileInfo, string layerName)
        {
            tileInfo = Instantiate(_tileInfoTemplate, _content);
            tileInfo.Init(layerName);
        }
    }
}
