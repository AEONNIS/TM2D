using System;

namespace TM2D.UI
{
    [AttributeUsage(AttributeTargets.Property)]
    public class UIStringAttribute : UIAttribute
    {
        public override string Label { get; }

        public UIStringAttribute(string label) => Label = label;
    }
}
