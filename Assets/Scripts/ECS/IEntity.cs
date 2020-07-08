using System.Collections.Generic;

namespace TM2D.ECS
{
    public interface IEntity
    {
        IReadOnlyList<IComponent> GetComponents();

        void Add(IComponent component);

        bool Remove(IComponent component);
    }
}
