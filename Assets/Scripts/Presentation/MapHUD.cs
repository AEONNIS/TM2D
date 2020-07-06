using UnityEngine;
using UnityEngine.Tilemaps;

namespace TM2D.Presentation
{
    public class MapHUD : MonoBehaviour
    {
        [SerializeField] private Tilemap _hudTilemap;
        [SerializeField] private Sprite _tileBacklightSprite;
        [SerializeField] private Color _tileBacklightColor;

        private Tile _emptyTile;
        private Tile _tileBacklight;
        private Vector3Int _backlightedTilePosition;

        #region Unity
        private void Start()
        {
            _emptyTile = ScriptableObject.CreateInstance<Tile>();
            _tileBacklight = ScriptableObject.CreateInstance<Tile>();
            _tileBacklight.sprite = _tileBacklightSprite;
            _tileBacklight.color = _tileBacklightColor;
        }
        #endregion

        public void BacklightTile(Vector3Int gridPosition)
        {
            _hudTilemap.SetTile(_backlightedTilePosition, _emptyTile);
            _backlightedTilePosition = gridPosition;
            _hudTilemap.SetTile(_backlightedTilePosition, _tileBacklight);
        }
    }
}
