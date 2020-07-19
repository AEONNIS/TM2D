using System;
using UnityEngine;

namespace TM2D.ECS
{
    [Serializable]
    public class SOSystemOrder : ISystemOrder
    {
        [SerializeField] private int _order;
        [SerializeField] private SOSystem _sOSystem;

        public int Order => _order;

        public ISystem System => _sOSystem;
    }
}
