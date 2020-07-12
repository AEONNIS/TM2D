using UnityEngine;

namespace TM2D.ECS
{
    public class MBEntity : MonoBehaviour, IEntity
    {
        [SerializeField] private ComponentsContainer _componentsContainer;

        public IComponentsContainer ComponentsContainer => _componentsContainer;
    }
}
