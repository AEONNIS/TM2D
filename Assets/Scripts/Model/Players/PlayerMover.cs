using UnityEngine;

namespace TM2D.Model.Players
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private Vector2Int _startPosition;

        #region Unity
        private void Start()
        {
            SetPosition(_startPosition);
        }
        #endregion

        public void SetPosition(Vector2Int gridPosition) => transform.position = (Vector3Int)gridPosition;
    }
}
