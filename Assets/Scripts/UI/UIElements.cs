using System;
using System.Reflection;
using TM2D.ECS;
using UnityEngine;

namespace TM2D.UI
{
    public class UIElements : MonoBehaviour
    {
        [SerializeField] private UITextElement _textTemplate;
        // [SerializeField] private UIImageElement _imageTemplate;

        public void PresentAllUIComponents(IEntity entity, Transform content)
        {
            foreach (var component in entity.Components.Get())
            {
                if (component is IUIComponent)
                    Present(component as IUIComponent, content);
            }
        }

        private void Present(IUIComponent component, Transform content)
        {
            PropertyInfo[] properties = component.GetType().GetProperties();
            foreach (var property in properties)
            {
                TryPresentPropertyAs(_textTemplate, content, component, property);
                // TryPresentPropertyAs(_imageTemplate, content, component, property);
            }
        }

        private bool TryPresentPropertyAs(UITextElement textTemplate, Transform content, IUIComponent component, PropertyInfo property)
        {
            UITextAttribute textAttribute = (UITextAttribute)Attribute.GetCustomAttribute(property, typeof(UITextAttribute));
            if (textAttribute != null)
            {
                UITextElement text = Instantiate(textTemplate, content);
                text.Set(textAttribute.Label, (string)property.GetValue(component));
                return true;
            }
            return false;
        }

        private bool TryPresentPropertyAs(UIImageElement imageTemplate, Transform content, IUIComponent component, PropertyInfo property)
        {
            UIImageAttribute imageAttribute = (UIImageAttribute)Attribute.GetCustomAttribute(property, typeof(UIImageAttribute));
            if (imageAttribute != null)
            {
                UIImageElement image = Instantiate(imageTemplate, content);
                image.Set(imageAttribute.Label, (Sprite)property.GetValue(component));
                return true;
            }
            return false;
        }
    }
}
