using System;
using System.Collections.Generic;
using UnityEngine;

namespace TM2D.ECS
{
    [Serializable]
    public class ComponentsContainer : IComponentsContainer
    {
        [SerializeField] private List<SOComponent> _soComponents;

        private List<IComponent> _components = null;

        public IReadOnlyList<IComponent> GetComponents()
        {
            CreateComponentsIfNull();
            return _components;
        }

        public void Add(IComponent component)
        {
            CreateComponentsIfNull();
            _components.Add(component);
        }

        public bool Remove(IComponent component)
        {
            CreateComponentsIfNull();
            return _components.Remove(component);
        }

        private void CreateComponentsIfNull()
        {
            if (_components == null)
                _components = new List<IComponent>(_soComponents);
        }
    }
}
