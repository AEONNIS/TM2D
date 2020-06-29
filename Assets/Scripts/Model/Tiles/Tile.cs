using UnityEngine;

namespace TM2D.Model.Tiles
{
    public class Tile : MonoBehaviour
    {
        [SerializeField] private TileData _data;

        public TileData Data => _data;
    }
}
