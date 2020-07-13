using System.Collections.Generic;
using UnityEngine;

namespace TM2D.ECS
{
    public class MBSystemsContainer : MonoBehaviour, ISystemsContainer
    {
        [SerializeField] private List<MBSystem> _mbSystems = new List<MBSystem>();
        [SerializeField] private List<SOSystem> _soSystems = new List<SOSystem>();

        private List<ISystem> _systems = null;

        #region Unity
        private void Start() => CreateSystemsIfNull();
        #endregion

        public void Process(IEntity rawEntity)
        {
            foreach (var system in _systems)
            {
                system.ProcessIfPossible(rawEntity);
            }
        }

        private void CreateSystemsIfNull()
        {
            if (_systems == null)
            {
                _systems = new List<ISystem>(_mbSystems);
                _systems.AddRange(_soSystems);
            }
        }
    }
}
