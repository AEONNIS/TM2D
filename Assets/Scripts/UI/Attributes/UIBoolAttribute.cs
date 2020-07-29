using System;

namespace TM2D.UI
{
    [AttributeUsage(AttributeTargets.Property)]
    public class UIBoolAttribute : UIAttribute
    {
        public override string Label { get; }

        public UIBoolAttribute(string label) => Label = label;
    }
}
