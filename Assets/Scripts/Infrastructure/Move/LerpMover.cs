using System;
using System.Collections;
using TM2D.Model.Components.Move;
using UnityEngine;

namespace TM2D.Infrastructure.Move
{
    public class LerpMover : MonoBehaviour
    {
        private Coroutine _routine;

        public void Move(Transform target, Vector3 movement, LerpMoverData lerpMoverData, Action onEnd = null)
        {
            if (_routine != null)
                StopCoroutine(_routine);

            _routine = StartCoroutine(ToMove(target, movement, lerpMoverData, onEnd));
        }

        private IEnumerator ToMove(Transform target, Vector3 movement, LerpMoverData lerpMoverData, Action onEnd)
        {
            Vector3 endPosition = target.position + movement;

            while ((target.position - endPosition).sqrMagnitude > lerpMoverData.DeviationSquare)
            {
                target.position = Vector3.Lerp(target.position, endPosition, lerpMoverData.Speed * Time.deltaTime);
                yield return null;
            }

            target.position = endPosition;
            onEnd?.Invoke();
        }
    }
}
