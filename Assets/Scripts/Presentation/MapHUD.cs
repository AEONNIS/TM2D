using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

namespace TM2D.Presentation
{
    public class MapHUD : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private UI _ui;
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private Grid _grid;
        [SerializeField] private Tilemap _hud;
        [SerializeField] private Tile _emptyTile;
        [SerializeField] private Tile _tileBacklight;
        [SerializeField] private Color _backlightColor;

        private Vector3Int _backlightPosition;

        #region Unity
        private void Start()
        {
            _tileBacklight.color = _backlightColor;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Vector3Int gridPosition = _grid.WorldToCell(_mainCamera.ScreenToWorldPoint(Input.mousePosition));
            BacklightTile(gridPosition);
            _ui.PresentTilesInfo(gridPosition);
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
