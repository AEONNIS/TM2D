using TM2D.Infrastructure.Move;
using UnityEngine;

namespace TM2D.Model.Characters
{
    public class CharacterMover : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour _mover;
        [SerializeField] private Vector2Int _initPosition;

        private bool _isMoving;

        private IMover Mover => (IMover)_mover;

        #region Unity
        private void OnValidate()
        {
            if ((_mover is IMover) == false)
            {
                Debug.LogError(_mover.name + " needs to implement " + nameof(IMover));
                _mover = null;
            }
        }

        private void Start()
        {
            SetPosition(_initPosition);
        }
        #endregion

        public void MoveIn(Vector2Int gridPosition)
        {
            if (_isMoving == false)
            {
                _isMoving = true;
                Mover.Move(transform, (Vector2)gridPosition, () => _isMoving = false);
            }
        }

        private void SetPosition(Vector2Int gridPosition) => transform.position = (Vector3Int)gridPosition;
    }
}
