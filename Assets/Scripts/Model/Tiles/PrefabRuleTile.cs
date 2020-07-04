using UnityEngine;

namespace TM2D.Model.Tiles
{
    [CreateAssetMenu(fileName = "PrefabRuleTile", menuName = "TM2D/Model/Tiles/PrefabRuleTile")]
    public class PrefabRuleTile : RuleTile, ITile
    {
        [SerializeField] private Tile _prefab;

        public Tile Tile => _prefab;
    }
}
