using TM2D.ECS;

namespace TM2D.Infrastructure
{
    public class MovingEntity
    {
        public MovingEntity(IEntity entity, LerpMover mover)
        {
            Entity = entity;
            Mover = mover;
        }

        public IEntity Entity { get; set; }
        public LerpMover Mover { get; }
    }
}
