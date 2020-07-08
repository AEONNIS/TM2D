using System.Collections.Generic;

namespace TM2D.Model
{
    public class Entity
    {
        private List<Property> _properties;
    }

    public class Property
    {
        private Action _bindingAction;
    }

    public class Action
    {
        private List<Condition> _conditions;
    }

    public class Condition
    {

    }
}
