using TM2D.ECS;
using UnityEngine;

namespace TM2D.UI
{
    public class InfoModule : MonoBehaviour
    {
        [SerializeField] private Transform _layerTransform;
        [SerializeField] private string _layerLabel;
        [SerializeField] private UITextElement _layer;
        [SerializeField] private Transform _content;
        [SerializeField] private UIElements _uIElements;

        public void Init(string layerName) => _layer.Set(_layerLabel, layerName);

        public void Present(IEntity entity)
        {
            Clear();
            _uIElements.PresentAllUIComponents(entity, _content);
        }

        private void Clear()
        {
            foreach (Transform child in _content)
            {
                if (child != _layerTransform)
                    Destroy(child.gameObject);
            }
        }
    }
}
