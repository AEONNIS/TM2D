using System;

namespace TM2D.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class UiImageAttribute : Attribute
    {
        public string Name { get; }

        public UiImageAttribute(string name) => Name = name;
    }
}
