using System;

namespace TM2D.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class UiFloatValue : Attribute
    {
        public string Name { get; }

        public UiFloatValue(string name) => Name = name;
    }
}
