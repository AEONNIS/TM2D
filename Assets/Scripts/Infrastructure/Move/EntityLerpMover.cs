using TM2D.ECS;

namespace TM2D.Infrastructure.Move
{
    public class EntityLerpMover
    {
        public EntityLerpMover(IEntity entity, LerpMover mover)
        {
            Entity = entity;
            Mover = mover;
        }

        public IEntity Entity { get; set; }
        public LerpMover Mover { get; }
    }
}
