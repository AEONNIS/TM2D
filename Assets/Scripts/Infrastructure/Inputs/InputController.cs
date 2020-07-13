using TM2D.ECS;
using TM2D.Model.Components;
using UnityEngine;
using static TM2D.Infrastructure.Input;

namespace TM2D.Infrastructure
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private MBSystemsContainer _systems;
        [SerializeField] private MBEntity _player;

        private Input _input;

        public PlayerActions Player => _input.Player;

        #region Unity
        private void Awake() => _input = new Input();

        private void Start() => CreateMovementBindings(_player);

        private void OnEnable() => _input.Enable();

        private void OnDisable() => _input.Disable();
        #endregion

        private void CreateMovementBindings(IEntity entity)
        {
            Player.Up.performed += context => MoveIfNotMoving(entity, new MoveV2IntEvent(Vector2Int.up));
            Player.Down.performed += context => MoveIfNotMoving(entity, new MoveV2IntEvent(Vector2Int.down));
            Player.Left.performed += context => MoveIfNotMoving(entity, new MoveV2IntEvent(Vector2Int.left));
            Player.Right.performed += context => MoveIfNotMoving(entity, new MoveV2IntEvent(Vector2Int.right));
        }

        private void MoveIfNotMoving(IEntity entity, MoveV2IntEvent moveV2IntEvent)
        {
            if (entity.Components.TypeMissing<MoveV2IntEvent>())
            {
                entity.Components.Add(moveV2IntEvent);
                _systems.Process(entity);
            }
        }
    }
}
