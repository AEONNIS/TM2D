using TM2D.ECS;
using UnityEngine;

namespace TM2D.Model.Components
{
    public class TransformData : MonoBehaviour, IComponent
    {
        public Transform Transform => transform;
    }
}
