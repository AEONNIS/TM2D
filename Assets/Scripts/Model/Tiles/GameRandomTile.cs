using UnityEngine;
using UnityEngine.Tilemaps;

namespace TM2D.Model.Tiles
{
    [CreateAssetMenu(fileName = "GameRandomTile", menuName = "TM2D/Model/Tiles/GameRandomTile")]
    public class GameRandomTile : RandomTile, IGameTile
    {
        [SerializeField] private GameTileData _tileData;

        public GameTileData TileData => _tileData;
    }
}
