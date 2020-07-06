using UnityEngine;
using UnityEngine.Tilemaps;

namespace TM2D.Presentation
{
    public class MapHUD : MonoBehaviour
    {
        [SerializeField] private Tilemap _hudTilemap;
        [SerializeField] private Tile _emptyTile;
        [SerializeField] private Tile _tileBacklight;
        [SerializeField] private Color _backlightColor;

        private Vector3Int _backlightPosition;

        #region Unity
        private void Start()
        {
            _tileBacklight.color = _backlightColor;
        }
        #endregion

        public void BacklightTile(Vector3Int gridPosition)
        {
            _hudTilemap.SetTile(_backlightPosition, _emptyTile);
            _backlightPosition = gridPosition;
            _hudTilemap.SetTile(_backlightPosition, _tileBacklight);
        }
    }
}
