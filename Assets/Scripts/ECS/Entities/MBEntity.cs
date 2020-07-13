using UnityEngine;

namespace TM2D.ECS
{
    public class MBEntity : MonoBehaviour, IEntity
    {
        [SerializeField] private ComponentsContainer _components = new ComponentsContainer();

        #region Unity
        private void Awake() => _components.Init();
        #endregion

        public IComponentsContainer Components => _components;
    }
}
