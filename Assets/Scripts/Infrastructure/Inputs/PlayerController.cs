using TM2D.Model.Characters;
using UnityEngine;

namespace TM2D.Infrastructure.Inputs
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputController _input;
        [SerializeField] private CharacterMover _mover;

        #region Unity
        private void Start()
        {
            _input.Player.Up.performed += context =>
                   _mover.MoveIn(Vector2Int.RoundToInt(transform.position) + Vector2Int.up);

            _input.Player.Down.performed += context =>
                   _mover.MoveIn(Vector2Int.RoundToInt(transform.position) + Vector2Int.down);

            _input.Player.Left.performed += context =>
                   _mover.MoveIn(Vector2Int.RoundToInt(transform.position) + Vector2Int.left);

            _input.Player.Right.performed += context =>
                   _mover.MoveIn(Vector2Int.RoundToInt(transform.position) + Vector2Int.right);
        }
        #endregion
    }
}
