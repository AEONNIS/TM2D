using System.Collections.Generic;
using TM2D.ECS;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TM2D.Model.Entities
{
    [CreateAssetMenu(fileName = "RandomTileEntity", menuName = "TM2D/Model/Entities/RandomTileEntity")]
    public class RandomTileEntity : RandomTile, IEntity
    {
        [SerializeField] private List<ScriptableObjectComponent> _soComponents;

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
