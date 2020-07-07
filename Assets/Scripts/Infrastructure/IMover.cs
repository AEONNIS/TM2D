using System;
using UnityEngine;

namespace TM2D.Infrastructure
{
    public interface IMover
    {
        void Move(Transform target, Vector3 endPosition, Action onEnd = null);
    }
}
