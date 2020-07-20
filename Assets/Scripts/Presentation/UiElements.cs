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

        public void InstantiateElement(IComponent component, Transform content)
        {
            Type componentType = component.GetType();
            UiComponentAttribute componentAttribute = (UiComponentAttribute)Attribute.
                GetCustomAttribute(componentType, typeof(UiComponentAttribute));

            if (componentAttribute != null)
            {
                PropertyInfo[] properties = componentType.GetProperties();
                foreach (var property in properties)
                {
                    Type propertyType = property.GetType();
                    UiBoolAttribute uiBoolValueAttribute = (UiBoolAttribute)Attribute.
                        GetCustomAttribute(propertyType, typeof(UiBoolAttribute));

                    if (uiBoolValueAttribute != null)
                    {
                        UiImage uiBoolField = Instantiate(_imageTemplate, content);
                        uiBoolField.SetField()
                    }
                }
            }
        }
    }
}
