using UnityEngine;
using UnityEngine.UI;

namespace TM2D.Presentation
{
    public class UiImage : MonoBehaviour
    {
        [SerializeField] private Text _label;
        [SerializeField] private Image _value;

        public void SetField(string label, Sprite value)
        {
            _label.text = label;
            _value.sprite = value;
        }
    }
}
