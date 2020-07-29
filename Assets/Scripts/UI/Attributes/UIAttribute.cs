using System;

namespace TM2D.UI
{
    public abstract class UIAttribute : Attribute
    {
        public abstract string Label { get; }
    }
}
