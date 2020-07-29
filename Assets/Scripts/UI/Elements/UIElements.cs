using System;
using System.Reflection;
using TM2D.ECS;
using UnityEngine;

namespace TM2D.UI
{
    public class UIElements : MonoBehaviour
    {
        [SerializeField] private UITextElement _textTemplate;

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
                TryPresentProperty<UIStringAttribute>(component, property, content, _textTemplate);
                TryPresentProperty<UIBoolAttribute>(component, property, content, _textTemplate);
            }
        }

        private bool TryPresentProperty<T>(IUIComponent component, PropertyInfo property, Transform content, UITextElement textTemplate) where T : UIAttribute
        {
            T attribite = (T)Attribute.GetCustomAttribute(property, typeof(T));
            if (attribite != null)
            {
                UITextElement text = Instantiate(textTemplate, content);

                if (attribite is UIStringAttribute)
                    text.Set(attribite.Label, GetValueForString(component, property));
                else if (attribite is UIBoolAttribute)
                    text.Set(attribite.Label, GetValueForBool(component, property));

                return true;
            }
            return false;
        }

        private string GetValueForString(IUIComponent component, PropertyInfo property) => (string)property.GetValue(component);

        private string GetValueForBool(IUIComponent component, PropertyInfo property) => (bool)property.GetValue(component) ? "+" : "-";
    }
}
