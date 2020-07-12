using TM2D.ECS;
using UnityEngine;

namespace TM2D.Model.Components.Move
{
    public class LerpMoverData : MonoBehaviour, IComponent
    {
        [Range(0.01f, 100f)]
        [SerializeField] private float _speed = 8f;
        [Range(0.00001f, 1000f)]
        [SerializeField] private float _deviationSquare = 0.01f;

        public float Speed => _speed;
        public float DeviationSquare => _deviationSquare;
    }
}
