using TM2D.Model.Characters;
using UnityEngine;

namespace TM2D.Infrastructure.Inputs
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputController _inputController;
        [SerializeField] private CharacterMover _mover;

        #region Unity
        private void Start()
        {
            _inputController.Input.Player.Up.performed += context =>
                             _mover.MoveIn(Vector2Int.RoundToInt(transform.position) + Vector2Int.up);

            _inputController.Input.Player.Down.performed += context =>
                             _mover.MoveIn(Vector2Int.RoundToInt(transform.position) + Vector2Int.down);

            _inputController.Input.Player.Left.performed += context =>
                             _mover.MoveIn(Vector2Int.RoundToInt(transform.position) + Vector2Int.left);

            _inputController.Input.Player.Right.performed += context =>
                             _mover.MoveIn(Vector2Int.RoundToInt(transform.position) + Vector2Int.right);
        }
        #endregion
    }
}
