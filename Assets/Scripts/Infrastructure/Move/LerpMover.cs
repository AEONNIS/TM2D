using System;
using System.Collections;
using UnityEngine;

namespace TM2D.Infrastructure.Move
{
    public class LerpMover : Mover
    {
        [Range(0.01f, 100f)]
        [SerializeField] private float _speed = 0.2f;
        [Range(0.00001f, 1000f)]
        [SerializeField] private float _deviationSquare = 0.00001f;

        private Coroutine _routine;

        public override void Move(Transform target, Vector3 endPosition, Action onEnd = null)
        {
            if (_routine != null)
                StopCoroutine(_routine);

            _routine = StartCoroutine(ToMove(target, endPosition, onEnd));
        }

        private IEnumerator ToMove(Transform target, Vector3 endPosition, Action onEnd = null)
        {
            while ((target.position - endPosition).sqrMagnitude > _deviationSquare)
            {
                target.position = Vector3.Lerp(target.position, endPosition, _speed * Time.deltaTime);
                yield return null;
            }

            target.position = endPosition;
            onEnd?.Invoke();
        }
    }
}
