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

        private UIElements _uIElements;

        public void Init(string layerName, UIElements uIElements)
        {
            _layer.Set(_layerLabel, layerName);
            _uIElements = uIElements;
            gameObject.SetActive(false);
        }

        public void Present(IEntity entity)
        {
            if (entity != null)
            {
                gameObject.SetActive(true);
                Clear();
                _uIElements.PresentAllUIComponents(entity, _content);
            }
            else
            {
                gameObject.SetActive(false);
            }
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
