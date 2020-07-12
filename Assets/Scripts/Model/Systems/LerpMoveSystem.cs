using TM2D.ECS;
using TM2D.Infrastructure.Move;
using TM2D.Model.Components;
using TM2D.Model.Components.Move;
using UnityEngine;

namespace TM2D.Model.Systems
{
    public class LerpMoveSystem : ISystem
    {
        [SerializeField] private LerpMoversPool _pool;

        private readonly ISystemsContainer _systemsContainer;

        public LerpMoveSystem(ISystemsContainer systemsContainer) => _systemsContainer = systemsContainer;

        public IEntity ProcessIfPossible(IEntity entity)
        {
            (TransformData transformData, MoveEventV2Int moveEvent, LerpMoverData moverData) components =
                                                                         GetComponentsIfAvailable(entity);

            if (components.transformData != null && components.moveEvent != null && components.moverData != null)
                _pool.Move(entity, components.transformData.Transform, (Vector2)components.moveEvent.Movement,
                           components.moverData, () =>
                {
                    entity.ComponentsContainer.Remove(components.moveEvent);
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
