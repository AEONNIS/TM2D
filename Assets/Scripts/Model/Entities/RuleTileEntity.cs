using System.Collections.Generic;
using TM2D.ECS;
using UnityEngine;

namespace TM2D.Model.Entities
{
    [CreateAssetMenu(fileName = "RuleTileEntity", menuName = "TM2D/Model/Components/RuleTileEntity")]
    public class RuleTileEntity : RuleTile, IEntity
    {
        [SerializeField] private List<SOComponent> _soComponents;

        private List<IComponent> _components = new List<IComponent>();

        public IReadOnlyList<IComponent> GetComponents()
        {
            List<IComponent> components = new List<IComponent>(_components);
            components.AddRange(_soComponents);
            return components;
        }

        public void Add(IComponent component) => _components.Add(component);

        public void Remove(IComponent component) => _components.Remove(component);
    }
}
