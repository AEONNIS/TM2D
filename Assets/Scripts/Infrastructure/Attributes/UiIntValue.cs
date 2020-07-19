using System;

namespace TM2D.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class UiIntValue : Attribute
    {
        public string Name { get; }

        public UiIntValue(string name) => Name = name;
    }
}
