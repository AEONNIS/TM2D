using TM2D.ECS;
using UnityEngine;

namespace TM2D.Model.Entities
{
    [CreateAssetMenu(fileName = "RuleTileEntity", menuName = "TM2D/Model/Entities/RuleTileEntity")]
    public class RuleTileEntity : RuleTile, IEntity
    {
        [SerializeField] private ComponentsContainer _componentsContainer;

        public IComponentsContainer ComponentContainer => _componentsContainer;
    }
}
