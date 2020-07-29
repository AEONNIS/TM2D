using UnityEngine;
using UnityEngine.UI;

namespace TM2D.UI
{
    public class UIImageElement : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Image _image;

        public void Set(Sprite sprite, Vector2 size)
        {
            _image.sprite = sprite;
            _rectTransform.sizeDelta = size;
            _image.rectTransform.sizeDelta = size;
        }
    }
}
