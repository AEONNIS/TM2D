namespace TM2D.ECS
{
    public interface ISystem
    {
        IEntity ProcessIfPossible(IEntity entity);
    }
}
