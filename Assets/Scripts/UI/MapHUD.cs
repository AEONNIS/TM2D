using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

namespace TM2D.UI
{
    public class MapHUD : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private Grid _grid;
        [SerializeField] private Tilemap _hud;
        [SerializeField] private Tile _emptyTile;
        [SerializeField] private Tile _tileBacklight;
        [SerializeField] private Color _backlightColor;
        [SerializeField] private UserInterface _userInterface;

        private Vector3Int _backlightPosition;

        #region Unity
        private void Start() => _tileBacklight.color = _backlightColor;

        public void OnPointerClick(PointerEventData eventData)
        {
            Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector3Int gridPosition = _grid.WorldToCell(worldPosition);
            BacklightTile(gridPosition);
            _userInterface.PresentEntitiesInfoIn(gridPosition);
        }
        #endregion

        private void BacklightTile(Vector3Int gridPosition)
        {
            _hud.SetTile(_backlightPosition, _emptyTile);
            _backlightPosition = gridPosition;
            _hud.SetTile(_backlightPosition, _tileBacklight);
        }
    }
}
