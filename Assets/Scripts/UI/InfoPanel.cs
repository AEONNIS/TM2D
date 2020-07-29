using TM2D.ECS;
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
        [SerializeField] private Vector2 _imageElementSize;

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
            (IEntity entity, Sprite sprite) backgroundTile = _map.GetTileIn(LayerName.Background, cursorPosition);
            (IEntity entity, Sprite sprite) foregroundTile = _map.GetTileIn(LayerName.Foreground, cursorPosition);
            _background.Present(backgroundTile.entity, (backgroundTile.sprite, _imageElementSize));
            _foreground.Present(foregroundTile.entity, (foregroundTile.sprite, _imageElementSize));
        }

        private InfoModule SetModule(LayerName layerName)
        {
            InfoModule module = Instantiate(_moduleTemplate, _content);
            module.Init(layerName.ToString(), _uIElements);
            return module;
        }
    }
}
