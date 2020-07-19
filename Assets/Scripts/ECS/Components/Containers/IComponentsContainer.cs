using System.Collections.Generic;

namespace TM2D.ECS
{
    public interface IComponentsContainer
    {
        void Init();

        IReadOnlyList<IComponent> Get();

        void Add(IComponent component);

        bool AddIfTypeMissing<T>(T component) where T : IComponent;

        bool TypeMissing<T>() where T : IComponent;

        bool Remove(IComponent component);
    }
}
