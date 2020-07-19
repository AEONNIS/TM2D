using System.Collections.Generic;
using UnityEngine;

namespace TM2D.ECS
{
    public class MBSystemsContainer : MonoBehaviour, ISystemsContainer
    {
        [SerializeField] private List<MBSystemOrder> _mBSystems = new List<MBSystemOrder>();
        [SerializeField] private List<SOSystemOrder> _sOSystems = new List<SOSystemOrder>();

        private SortedList<int, ISystem> _systems = null;

        #region Unity
        private void Awake() => CombineSystems();
        #endregion

        public void Process(IEntity rawEntity)
        {
            foreach (var system in _systems.Values)
            {
                system.ProcessIfPossible(rawEntity);
            }
        }

        private void CombineSystems()
        {
            if (_systems == null)
            {
                _systems = new SortedList<int, ISystem>();
                AddInSystems(_systems, _mBSystems);
                AddInSystems(_systems, _sOSystems);
            }
        }

        private void AddInSystems<T>(SortedList<int, ISystem> systems, List<T> systemOrders) where T : ISystemOrder
        {
            foreach (var systemOrder in systemOrders)
                systems.Add(systemOrder.Order, systemOrder.System);
        }
    }
}
