using TM2D.Model.Maps;
using UnityEngine;

namespace TM2D.UI
{
    public class InfoPanel : MonoBehaviour
    {
        [SerializeField] private UITextElement _cursorPosition;
        [SerializeField] private InfoModule _moduleTemplate;
        [SerializeField] private Transform _content;
        [SerializeField] private UIElements _uIElements;
        [SerializeField] private Map _map;

        private InfoModule _background;
        private InfoModule _foreground;

        public void Init()
        {
            _cursorPosition.Set("");
            _background = SetModule(LayerName.Background);
            _foreground = SetModule(LayerName.Foreground);
        }

        public void Present(Vector3Int cursorPosition)
        {
            _cursorPosition.Set(cursorPosition.ToString());
            _background.Present(_map.GetTileEntityIn(LayerName.Background, cursorPosition));
            _foreground.Present(_map.GetTileEntityIn(LayerName.Foreground, cursorPosition));
        }

        private InfoModule SetModule(LayerName layerName)
        {
            InfoModule module = Instantiate(_moduleTemplate, _content);
            module.Init(layerName.ToString(), _uIElements);
            return module;
        }
    }
}
