using UnityEngine;

namespace TM2D.Model.Tiles
{
    [CreateAssetMenu(fileName = "GameRuleTile", menuName = "TM2D/Model/Tiles/GameRuleTile")]
    public class GameRuleTile : RuleTile, IGameTile
    {
        [SerializeField] private GameTileData _tileData;

        public GameTileData TileData => _tileData;
    }
}
