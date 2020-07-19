using TM2D.ECS;
using TM2D.Model.Components;
using TM2D.Model.Maps;
using UnityEngine;

namespace TM2D.Model.Systems
{
    public class PassabilityCheckSystem : MBSystem
    {
        [SerializeField] private MBSystemsContainer _systems;
        [SerializeField] private Map _map;

        public override IEntity ProcessIfPossible(IEntity entity)
        {
            (TransformData source, MoveV2IntEvent toDestination) = GetComponentIfAvailable(entity);

            if (source != null && toDestination != null && DestinationIsPassable(source, toDestination) == false)
                entity.Components.Remove(toDestination);

            return entity;
        }

        private (TransformData, MoveV2IntEvent) GetComponentIfAvailable(IEntity entity)
        {
            (TransformData source, MoveV2IntEvent toDestination) components = (null, null);

            foreach (var component in entity.Components.Get())
            {
                if (component is TransformData)
                    components.source = component as TransformData;
                else if (component is MoveV2IntEvent)
                    components.toDestination = component as MoveV2IntEvent;
            }
            return components;
        }

        private Vector3Int GetDestinationPosition(TransformData source, MoveV2IntEvent toDestination)
        {
            return Vector3Int.RoundToInt(source.transform.position) + (Vector3Int)toDestination.Movement;
        }

        private IEntity GetTileInDestination(LayerName layer, Vector3Int destinationPosition)
        {
            return _map.GetTileIn(layer, destinationPosition);
        }

        private bool TileIsPassable(IEntity tile)
        {
            if (tile != null)
            {
                foreach (var component in tile.Components.Get())
                {
                    if (component is PassabilityState)
                        return (component as PassabilityState).Passability;
                }
            }
            return true;
        }

        private bool DestinationIsPassable(TransformData source, MoveV2IntEvent toDestination)
        {
            Vector3Int destinatinPosition = GetDestinationPosition(source, toDestination);
            return TileIsPassable(GetTileInDestination(LayerName.Background, destinatinPosition)) &&
                   TileIsPassable(GetTileInDestination(LayerName.Foreground, destinatinPosition));
        }
    }
}
