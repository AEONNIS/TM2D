using TM2D.Model.Tiles;
using UnityEngine;
using UnityEngine.UI;

namespace TM2D.Presentation.InfoPanel
{
    public class TileInfo : MonoBehaviour
    {
        [SerializeField] private Text _layerName;
        [SerializeField] private Text _type;
        [SerializeField] private Text _name;
        [SerializeField] private Text _description;
        [SerializeField] private Text _passability;

        public void Init(string layerName)
        {
            _layerName.text = layerName;
            Hide();
        }

        public void Present(GameTileData tileData)
        {
            _type.text = tileData.Type;
            _name.text = tileData.Name;
            _description.text = tileData.Description;
            _passability.text = tileData.Passability ? "+" : "-";
            gameObject.SetActive(true);
        }

        public void Hide() => gameObject.SetActive(false);
    }
}
