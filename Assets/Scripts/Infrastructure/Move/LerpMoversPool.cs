using System;
using System.Collections.Generic;
using TM2D.ECS;
using TM2D.Model.Components.Move;
using UnityEngine;

namespace TM2D.Infrastructure.Move
{
    public class LerpMoversPool : MonoBehaviour
    {
        [SerializeField] private Transform _content;
        [SerializeField] private LerpMover _lerpMoverTemplate;

        private List<EntityLerpMover> _pool = new List<EntityLerpMover>();

        public void Move(IEntity entity, Transform target, Vector3 movement,
                         LerpMoverData lerpMoverData, Action onEnd = null)
        {
            if (EntityMoves(entity))
            {
                return;
            }
            else
            {
                EntityLerpMover entityLerpMover = GetFree(entity);
                entityLerpMover.Mover.Move(target, movement, lerpMoverData, () =>
                {
                    entityLerpMover.Entity = null;
                    onEnd?.Invoke();
                });
            }
        }

        private bool EntityMoves(IEntity entity)
        {
            foreach (var entityLerpMover in _pool)
            {
                if (entityLerpMover.Entity == entity)
                    return true;
            }
            return false;
        }

        private EntityLerpMover GetFree(IEntity entity)
        {
            foreach (var entityLerpMover in _pool)
            {
                if (entityLerpMover.Entity == null)
                {
                    entityLerpMover.Entity = entity;
                    return entityLerpMover;
                }
            }
            return Create(entity);
        }

        private EntityLerpMover Create(IEntity entity)
        {
            LerpMover lerpMover = Instantiate(_lerpMoverTemplate, _content);
            _pool.Add(new EntityLerpMover(entity, lerpMover));
            return _pool[_pool.Count - 1];
        }
    }
}
