using System;
using UnityEngine;

namespace TM2D.Infrastructure.Move
{
    public abstract class Mover : MonoBehaviour
    {
        public abstract void Move(Transform target, Vector3 endPosition, Action onEnd = null);
    }
}
