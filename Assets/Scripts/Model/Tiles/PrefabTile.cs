using UnityEngine;
using UnityEngine.Tilemaps;

namespace TM2D.Model.Tiles
{
    [CreateAssetMenu(fileName = "PrefabTile", menuName = "TM2D/Model/Tiles/PrefabTile")]
    public class PrefabTile : TerrainTile
    {
        [SerializeField] private Tile _prefab;

        public Tile Prefab => _prefab;
    }
}
