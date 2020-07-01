using UnityEngine;
using UnityEngine.Tilemaps;

namespace TM2D.Model.Tiles
{
    [CreateAssetMenu(fileName = "PrefabRandomTile", menuName = "TM2D/Model/Tiles/PrefabRandomTile")]
    public class PrefabRandomTile : RandomTile
    {
        [SerializeField] private Tile _prefab;

        public Tile Prefab => _prefab;
    }
}
