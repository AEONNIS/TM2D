using System;
using System.Collections.Generic;
using UnityEngine;

namespace TM2D.ECS
{
    [Serializable]
    public class ComponentsContainer : IComponentsContainer
    {
        [SerializeField] private List<MBComponent> _mBComponents = new List<MBComponent>();
        [SerializeField] private List<SOComponent> _sOComponents = new List<SOComponent>();

        private List<IComponent> _components = null;

        public void Init() => CombineComponents();

        public IReadOnlyList<IComponent> Get() => _components;

        public void Add(IComponent component) => _components.Add(component);

        public bool AddIfTypeMissing<T>(T component) where T : IComponent
        {
            if (TypeMissing<T>())
            {
                Add(component);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool TypeMissing<T>() where T : IComponent
        {
            foreach (var component in _components)
            {
                if (component is T)
                    return false;
            }
            return true;
        }

        public bool Remove(IComponent component) => _components.Remove(component);

        private void CombineComponents()
        {
            if (_components == null)
            {
                _components = new List<IComponent>(_mBComponents);
                _components.AddRange(_sOComponents);
            }
        }
    }
}
