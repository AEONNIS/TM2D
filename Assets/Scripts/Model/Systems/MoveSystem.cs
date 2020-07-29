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
            (TransformDataComponent source, MoveV2IntEventComponent moveEvent, LerpMoverDataComponent moverData) =
                GetComponentsIfAvailable(entity);

            if (source != null && moveEvent != null && moverData != null)
            {
                _pool.Move(entity, source.Transform, (Vector2)moveEvent.Movement, moverData,
                           () => entity.Components.Remove(moveEvent));
            }
            return entity;
        }

        private (TransformDataComponent, MoveV2IntEventComponent, LerpMoverDataComponent) GetComponentsIfAvailable(IEntity entity)
        {
            (TransformDataComponent source, MoveV2IntEventComponent moveEvent, LerpMoverDataComponent moverData) components =
                (null, null, null);

            foreach (var component in entity.Components.Get())
            {
                if (component is TransformDataComponent)
                    components.source = component as TransformDataComponent;
                else if (component is MoveV2IntEventComponent)
                    components.moveEvent = component as MoveV2IntEventComponent;
                else if (component is LerpMoverDataComponent)
                    components.moverData = component as LerpMoverDataComponent;
            }
            return components;
        }
    }
}
