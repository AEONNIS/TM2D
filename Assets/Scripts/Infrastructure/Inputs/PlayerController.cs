using TM2D.ECS;
using TM2D.Model.Components.Move;
using UnityEngine;

namespace TM2D.Infrastructure.Inputs
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputController _input;
        [SerializeField] private MBSystemsContainer _systemsContainer;
        [SerializeField] private MBEntity _player;

        #region Unity
        private void Start()
        {
            _input.Player.Up.performed += context => Move(_player, new MoveEventV2Int(Vector2Int.up));
            _input.Player.Down.performed += context => Move(_player, new MoveEventV2Int(Vector2Int.down));
            _input.Player.Left.performed += context => Move(_player, new MoveEventV2Int(Vector2Int.left));
            _input.Player.Right.performed += context => Move(_player, new MoveEventV2Int(Vector2Int.right));
        }
        #endregion

        private void Move(IEntity entity, MoveEventV2Int moveEventV2Int)
        {
            entity.ComponentsContainer.Add(moveEventV2Int);
            _systemsContainer.Process(entity);
        }
    }
}
