using TM2D.Model.Maps;
using UnityEngine;
using UnityEngine.UI;

namespace TM2D.Presentation
{
    public class TileInfo : MonoBehaviour
    {
        [SerializeField] private Text _layerName;
        [SerializeField] private Text _type;
        [SerializeField] private Text _name;
        [SerializeField] private Image _image;
        [SerializeField] private Text _description;
        [SerializeField] private Text _passability;

        public void Init(LayerName mapLayerName)
        {
            _layerName.text = mapLayerName.ToString();
            Hide();
        }

        //public void Present((GameTileData data, Sprite sprite) tile)
        //{
        //    if (tile.data != null)
        //    {
        //        _type.text = tile.data.Type;
        //        _name.text = tile.data.Name;
        //        _image.sprite = tile.sprite;
        //        _description.text = tile.data.Description;
        //        _passability.text = tile.data.Passability ? "+" : "-";
        //        gameObject.SetActive(true);
        //    }
        //    else
        //    {
        //        Hide();
        //    }
        //}

        public void Hide() => gameObject.SetActive(false);
    }
}
