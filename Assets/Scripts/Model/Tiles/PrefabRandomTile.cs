using UnityEngine;
using UnityEngine.Tilemaps;

namespace TM2D.Model.Tiles
{
    [CreateAssetMenu(fileName = "PrefabRandomTile", menuName = "TM2D/Model/Tiles/PrefabRandomTile")]
    public class PrefabRandomTile : RandomTile, ITile
    {
        [SerializeField] private Tile _prefab;

        public Tile Tile => _prefab;
    }
}
