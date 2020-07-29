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
            (TransformDataComponent source, MoveV2IntEventComponent toDestination) = GetComponentIfAvailable(entity);

            if (source != null && toDestination != null && DestinationIsPassable(source, toDestination) == false)
                entity.Components.Remove(toDestination);

            return entity;
        }

        private (TransformDataComponent, MoveV2IntEventComponent) GetComponentIfAvailable(IEntity entity)
        {
            (TransformDataComponent source, MoveV2IntEventComponent toDestination) components = (null, null);

            foreach (var component in entity.Components.Get())
            {
                if (component is TransformDataComponent)
                    components.source = component as TransformDataComponent;
                else if (component is MoveV2IntEventComponent)
                    components.toDestination = component as MoveV2IntEventComponent;
            }
            return components;
        }

        private Vector3Int GetDestinationPosition(TransformDataComponent source, MoveV2IntEventComponent toDestination)
        {
            return Vector3Int.RoundToInt(source.transform.position) + (Vector3Int)toDestination.Movement;
        }

        private IEntity GetTileInDestination(LayerName layer, Vector3Int destinationPosition)
        {
            return _map.GetEntityIn(layer, destinationPosition);
        }

        private bool TileIsPassable(IEntity tile)
        {
            if (tile != null)
            {
                foreach (var component in tile.Components.Get())
                {
                    if (component is PassabilityStateComponent)
                        return (component as PassabilityStateComponent).Passability;
                }
            }
            return true;
        }

        private bool DestinationIsPassable(TransformDataComponent source, MoveV2IntEventComponent toDestination)
        {
            Vector3Int destinatinPosition = GetDestinationPosition(source, toDestination);
            return TileIsPassable(GetTileInDestination(LayerName.Background, destinatinPosition)) &&
                   TileIsPassable(GetTileInDestination(LayerName.Foreground, destinatinPosition));
        }
    }
}
