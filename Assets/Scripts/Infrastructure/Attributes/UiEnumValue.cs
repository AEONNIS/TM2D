using System;

namespace TM2D.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class UiEnumValue : Attribute
    {
        public string Name { get; }

        public UiEnumValue(string name) => Name = name;
    }
}
