using System;

namespace TM2D.UI
{
    [AttributeUsage(AttributeTargets.Property)]
    public class UITextAttribute : Attribute
    {
        public string Label { get; }

        public UITextAttribute(string label) => Label = label;
    }
}
