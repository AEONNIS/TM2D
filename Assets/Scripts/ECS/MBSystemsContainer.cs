using System.Collections.Generic;
using TM2D.Model.Systems;
using UnityEngine;

namespace TM2D.ECS
{
    public class MBSystemsContainer : MonoBehaviour, ISystemsContainer
    {
        private List<ISystem> _systems;

        #region Unity
        private void Start() => CreateSystems();
        #endregion

        public void Process(IEntity rawEntity)
        {
            foreach (var system in _systems)
            {
                IEntity processedEntity = system.ProcessIfPossible(rawEntity);
                if (processedEntity != null)
                    Process(processedEntity);
            }
        }

        private void CreateSystems()
        {
            _systems = new List<ISystem>();
            _systems.Add(new LerpMoveSystem(this));
        }
    }
}
