using TM2D.ECS;
using TM2D.Infrastructure;
using TM2D.Model.Components;
using UnityEngine;

namespace TM2D.Model.Systems
{
    public class MoveSystem : MBSystem
    {
        [SerializeField] private MBSystemsContainer _systems;
        [SerializeField] private LerpMoversPool _pool;

        public override IEntity ProcessIfPossible(IEntity entity)
        {
            (TransformData source, MoveV2IntEvent moveEvent, LerpMoverData moverData) =
                GetComponentsIfAvailable(entity);

            if (source != null && moveEvent != null && moverData != null)
            {
                _pool.Move(entity, source.Transform, (Vector2)moveEvent.Movement, moverData,
                           () => entity.Components.Remove(moveEvent));
            }
            return entity;
        }

        private (TransformData, MoveV2IntEvent, LerpMoverData) GetComponentsIfAvailable(IEntity entity)
        {
            (TransformData source, MoveV2IntEvent moveEvent, LerpMoverData moverData) components =
                (null, null, null);

            foreach (var component in entity.Components.Get())
            {
                if (component is TransformData)
                    components.source = component as TransformData;
                else if (component is MoveV2IntEvent)
                    components.moveEvent = component as MoveV2IntEvent;
                else if (component is LerpMoverData)
                    components.moverData = component as LerpMoverData;
            }
            return components;
        }
    }
}
