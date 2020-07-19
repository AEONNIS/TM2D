using TM2D.Model.Maps;
using UnityEngine;
using UnityEngine.UI;

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

    public class UiFields
    {
        [SerializeField] private UiBoolField _boolTemplate;
        [SerializeField] private UiStringField _stringTemplate;
    }

    public class UiStringField : MonoBehaviour
    {
        [SerializeField] private Text _label;
        [SerializeField] private Text _field;

        public void SetField(string label, string field)
        {
            _label.text = label;
            _field.text = field;
        }
    }

    public class UiBoolField : MonoBehaviour
    {
        [SerializeField] private Text _label;
        [SerializeField] private Text _field;

        public void SetField(string label, bool field)
        {
            _label.text = label;
            _field.text = field ? "+" : "-";
        }
    }
}
