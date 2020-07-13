using UnityEngine;

namespace TM2D.ECS
{
    public abstract class SOSystem : ScriptableObject, ISystem
    {
        public abstract IEntity ProcessIfPossible(IEntity entity);
    }
}
