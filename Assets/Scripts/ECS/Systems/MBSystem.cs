using UnityEngine;

namespace TM2D.ECS
{
    public abstract class MBSystem : MonoBehaviour, ISystem
    {
        public abstract IEntity ProcessIfPossible(IEntity entity);
    }
}
