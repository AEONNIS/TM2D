namespace TM2D.ECS
{
    public interface ISystemOrder
    {
        int Order { get; }

        ISystem System { get; }
    }
}
