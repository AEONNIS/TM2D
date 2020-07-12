using TM2D.ECS;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TM2D.Model.Entities
{
    [CreateAssetMenu(fileName = "RandomTileEntity", menuName = "TM2D/Model/Entities/RandomTileEntity")]
    public class RandomTileEntity : RandomTile, IEntity
    {
        [SerializeField] private ComponentsContainer _componentsContainer;

        public IComponentsContainer ComponentsContainer => _componentsContainer;
    }
}
