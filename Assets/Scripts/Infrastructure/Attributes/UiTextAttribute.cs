using System;

namespace TM2D.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class UiTextAttribute : Attribute
    {
        public string Name { get; }

        public UiTextAttribute(string name) => Name = name;
    }
}
