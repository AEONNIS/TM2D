using UnityEngine;

namespace TM2D.ECS
{
    [CreateAssetMenu(fileName = "SOEntity", menuName = "TM2D/ECS/SOEntity")]
    public class SOEntity : ScriptableObject, IEntity
    {
        [SerializeField] private ComponentsContainer _components = new ComponentsContainer();

        #region Unity
        private void Awake() => _components.Init();
        #endregion

        public IComponentsContainer Components => _components;
    }
}
