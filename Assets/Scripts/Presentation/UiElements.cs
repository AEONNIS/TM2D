using System;
using System.Reflection;
using TM2D.ECS;
using TM2D.Infrastructure.Attributes;
using UnityEngine;

namespace TM2D.Presentation
{
    public class UIElements : MonoBehaviour
    {
        [SerializeField] private UIText _textTemplate;
        [SerializeField] private UIImage _imageTemplate;

        public void PresentAllUiComponents(IEntity entity, Transform content)
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
                Type propertyType = property.GetType();
                TryPresentPropertyAs(_textTemplate, content, component, property, propertyType);
                TryPresentPropertyAs(_imageTemplate, content, component, property, propertyType);
            }
        }

        private bool TryPresentPropertyAs(UIText textTemplate, Transform content, IUIComponent component, PropertyInfo property, Type propertyType)
        {
            UITextAttribute textAttribute = (UITextAttribute)Attribute.GetCustomAttribute(propertyType, typeof(UITextAttribute));
            if (textAttribute != null)
            {
                UIText text = Instantiate(textTemplate, content);
                text.Set(textAttribute.Label, (string)property.GetValue(component));
                return true;
            }
            return false;
        }

        private bool TryPresentPropertyAs(UIImage imageTemplate, Transform content, IUIComponent component, PropertyInfo property, Type propertyType)
        {
            UIImageAttribute imageAttribute = (UIImageAttribute)Attribute.GetCustomAttribute(propertyType, typeof(UIImageAttribute));
            if (imageAttribute != null)
            {
                UIImage image = Instantiate(imageTemplate, content);
                image.Set(imageAttribute.Label, (Sprite)property.GetValue(component));
                return true;
            }
            return false;
        }
    }
}
