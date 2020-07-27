using UnityEngine;
using UnityEngine.UI;

namespace TM2D.UI
{
    public class UITextElement : MonoBehaviour
    {
        [SerializeField] private Text _label;
        [SerializeField] private Text _value;

        public void Set(string label, string value)
        {
            _label.text = label;
            _value.text = value;
        }
    }
}
