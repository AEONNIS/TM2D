using TM2D.Infrastructure.Move;
using UnityEngine;

namespace TM2D.Model.Characters
{
    public class CharacterMover : MonoBehaviour
    {
        [SerializeField] private Mover _mover;
        [SerializeField] private Vector2Int _initPosition;

        private bool _isMoving;

        #region Unity
        private void Start() => SetPosition(_initPosition);
        #endregion

        public void MoveIn(Vector2Int gridPosition)
        {
            if (_isMoving == false)
            {
                _isMoving = true;
                _mover.Move(transform, (Vector2)gridPosition, () => _isMoving = false);
            }
        }

        private void SetPosition(Vector2Int gridPosition) => transform.position = (Vector3Int)gridPosition;
    }
}
