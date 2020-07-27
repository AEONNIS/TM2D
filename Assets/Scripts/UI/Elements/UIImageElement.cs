using UnityEngine;
using UnityEngine.UI;

namespace TM2D.UI
{
    public class UIImageElement : MonoBehaviour
    {
        [SerializeField] private Text _label;
        [SerializeField] private Image _value;

        public void Set(string label, Sprite value)
        {
            _label.text = label;
            _value.sprite = value;
        }
    }
}
