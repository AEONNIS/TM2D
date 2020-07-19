using System;

namespace TM2D.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class UiBoolValue : Attribute
    {
        public string Name { get; }

        public UiBoolValue(string name) => Name = name;
    }
}
