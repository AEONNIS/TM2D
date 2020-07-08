using TM2D.ECS;
using UnityEngine;

namespace TM2D.Model.Components
{
    [CreateAssetMenu(fileName = "PassabilityState", menuName = "TM2D/Model/Components/PassabilityState")]
    public class PassabilityState : ScriptableObjectComponent
    {
        public bool Passability;
    }

    public class ToPassable : IComponent { }

    public class ToImpassable : IComponent { }
}
