using TM2D.ECS;
using TM2D.Infrastructure.Move;
using TM2D.Model.Components;
using TM2D.Model.Components.Move;
using UnityEngine;

namespace TM2D.Model.Systems
{
    public class LerpMoveSystem : ISystem
    {
        private readonly ISystemsContainer _systemsContainer;
        private readonly LerpMoversPool _pool;

        public LerpMoveSystem(ISystemsContainer systemsContainer, LerpMoversPool lerpMoversPool)
        {
            _systemsContainer = systemsContainer;
            _pool = lerpMoversPool;
        }

        public IEntity ProcessIfPossible(IEntity entity)
        {
            (TransformData transformData, MoveEventV2Int moveEvent, LerpMoverData moverData) =
                                                                         GetComponentsIfAvailable(entity);

            if (transformData != null && moveEvent != null && moverData != null)
                _pool.Move(entity, transformData.Transform, (Vector2)moveEvent.Movement,
                           moverData, () =>
                {
                    entity.ComponentsContainer.Remove(moveEvent);
                    _systemsContainer.Process(entity);
                });

            return null;
        }

        private (TransformData, MoveEventV2Int, LerpMoverData) GetComponentsIfAvailable(IEntity entity)
        {
            (TransformData transformData, MoveEventV2Int moveEvent, LerpMoverData moverData) components =
                                                                                       (null, null, null);

            foreach (var component in entity.ComponentsContainer.GetComponents())
            {
                if (component is TransformData)
                    components.transformData = component as TransformData;
                else if (component is MoveEventV2Int)
                    components.moveEvent = component as MoveEventV2Int;
                else if (component is LerpMoverData)
                    components.moverData = component as LerpMoverData;
            }

            return components;
        }
    }
}
