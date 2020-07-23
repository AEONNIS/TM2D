using System;
using System.Reflection;
using TM2D.ECS;
using TM2D.Infrastructure.Attributes;
using UnityEngine;

namespace TM2D.Presentation
{
    public class UiElements : MonoBehaviour
    {
        [SerializeField] private UiText _textTemplate;
        [SerializeField] private UiImage _imageTemplate;

        public void PresentAllUiComponents(IEntity entity, Transform uiContent)
        {
            foreach (var component in entity.Components.Get())
            {
                if (component is IUiComponent)
                {

                }
            }
        }

        private void Present(IUiComponent uiComponent, Transform uiContent)
        {
            Type componentType = uiComponent.GetType();
            PropertyInfo[] properties = componentType.GetProperties();
            foreach (var property in properties)
            {
                Type propertyType = property.GetType();
                UiTextAttribute textAttribute = (UiTextAttribute)Attribute.GetCustomAttribute(propertyType, typeof(UiTextAttribute));

                if (textAttribute != null)
                {
                    UiText text = Instantiate(_textTemplate, uiContent);
                    text.Set(textAttribute.Label, (string)property.GetValue(uiComponent));
                }
            }
        }

        private void PresentProperty(IUiComponent uiComponent, PropertyInfo property, UiText textTemplate, Transform uiContent)
        {
            UiText text = Instantiate(textTemplate, uiContent);
            text.Set(textAttribute.Label, (string)property.GetValue(uiComponent));
        }
    }
}
