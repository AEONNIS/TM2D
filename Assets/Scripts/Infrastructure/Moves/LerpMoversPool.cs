using System;
using System.Collections.Generic;
using TM2D.ECS;
using TM2D.Model.Components;
using UnityEngine;

namespace TM2D.Infrastructure
{
    public class LerpMoversPool : MonoBehaviour
    {
        [SerializeField] private Transform _content;
        [SerializeField] private LerpMover _moverTemplate;

        private readonly List<MovingEntity> _pool = new List<MovingEntity>();

        public void Move(IEntity entity, Transform target, Vector3 movement,
                         LerpMoverData moverData, Action onEnd = null)
        {
            MovingEntity movingEntity = GetFree(entity);
            movingEntity.Mover.Move(target, movement, moverData, () =>
            {
                movingEntity.Entity = null;
                onEnd?.Invoke();
            });
        }

        private MovingEntity GetFree(IEntity entity)
        {
            foreach (var movingEntity in _pool)
            {
                if (movingEntity.Entity == null)
                {
                    movingEntity.Entity = entity;
                    return movingEntity;
                }
            }
            return Create(entity);
        }

        private MovingEntity Create(IEntity entity)
        {
            LerpMover mover = Instantiate(_moverTemplate, _content);
            MovingEntity movingEntity = new MovingEntity(entity, mover);
            _pool.Add(movingEntity);
            return movingEntity;
        }
    }
}
