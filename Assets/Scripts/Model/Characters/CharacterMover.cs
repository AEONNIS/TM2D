using TM2D.Infrastructure;
using UnityEngine;

namespace TM2D.Model.Characters
{
    public class CharacterMover : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour _mover;
        [SerializeField] private Vector2Int _initPosition;
        [SerializeField] private Vector2Int _endPosition;

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
            MoveIn(_endPosition);
        }
        #endregion

        public void MoveIn(Vector2Int gridPosition)
        {
            Mover.Move(transform, (Vector2)gridPosition, () => Debug.Log("Пришли"));
        }

        private void SetPosition(Vector2Int gridPosition) => transform.position = (Vector3Int)gridPosition;
    }
}
