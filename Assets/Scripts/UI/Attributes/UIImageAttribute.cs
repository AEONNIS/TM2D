using System;

namespace TM2D.UI
{
    [AttributeUsage(AttributeTargets.Property)]
    public class UIImageAttribute : Attribute
    {
        public string Label { get; }

        public UIImageAttribute(string label) => Label = label;
    }
}
