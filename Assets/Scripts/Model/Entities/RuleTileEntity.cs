using TM2D.ECS;
using UnityEngine;

namespace TM2D.Model.Entities
{
    [CreateAssetMenu(fileName = "RuleTileEntity", menuName = "TM2D/Model/Entities/RuleTileEntity")]
    public class RuleTileEntity : RuleTile, IEntity
    {
        [SerializeField] private ComponentsContainer _components = new ComponentsContainer();

        #region Unity
        private void Awake() => _components.Init();
        #endregion

        public IComponentsContainer Components => _components;
    }
}
