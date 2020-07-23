using System;

namespace TM2D.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class UiImageAttribute : Attribute
    {
        public string Label { get; }

        public UiImageAttribute(string label) => Label = label;
    }
}
