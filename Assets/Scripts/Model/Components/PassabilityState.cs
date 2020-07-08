using TM2D.ECS;
using UnityEngine;

namespace TM2D.Model.Components
{
    [CreateAssetMenu(fileName = "PassabilityState", menuName = "TM2D/Model/Components/PassabilityState")]
    public class PassabilityState : SOComponent
    {
        public bool Passability;
    }

    public class ToPassable : SOComponent { }

    public class ToImpassable : SOComponent { }
}
