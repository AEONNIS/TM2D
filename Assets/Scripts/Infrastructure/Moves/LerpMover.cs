using System;
using System.Collections;
using TM2D.Model.Components;
using UnityEngine;

namespace TM2D.Infrastructure
{
    public class LerpMover : MonoBehaviour
    {
        private Coroutine _routine;

        public void Move(Transform target, Vector3 movement, LerpMoverDataComponent moverData, Action onEnd = null)
        {
            if (_routine != null)
                StopCoroutine(_routine);

            _routine = StartCoroutine(ToMove(target, movement, moverData, onEnd));
        }

        private IEnumerator ToMove(Transform target, Vector3 movement, LerpMoverDataComponent moverData, Action onEnd)
        {
            Vector3 endPosition = target.position + movement;

            while ((target.position - endPosition).sqrMagnitude > moverData.DeviationSquare)
            {
                target.position = Vector3.Lerp(target.position, endPosition, moverData.Speed * Time.deltaTime);
                yield return null;
            }

            target.position = endPosition;
            onEnd?.Invoke();
        }
    }
}
