using System;

namespace TM2D.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class UiStringValue : Attribute
    {
        public string Name { get; }

        public UiStringValue(string name) => Name = name;
    }
}
