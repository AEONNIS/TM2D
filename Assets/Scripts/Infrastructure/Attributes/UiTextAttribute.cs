using System;

namespace TM2D.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class UiTextAttribute : Attribute
    {
        public string Label { get; }

        public UiTextAttribute(string label) => Label = label;
    }
}
