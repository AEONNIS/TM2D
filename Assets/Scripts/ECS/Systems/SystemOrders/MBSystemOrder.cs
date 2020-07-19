using System;
using UnityEngine;

namespace TM2D.ECS
{
    [Serializable]
    public class MBSystemOrder : ISystemOrder
    {
        [SerializeField] private int _order;
        [SerializeField] private MBSystem _mBSystem;

        public int Order => _order;

        public ISystem System => _mBSystem;
    }
}
