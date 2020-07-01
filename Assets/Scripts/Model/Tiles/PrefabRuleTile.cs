using UnityEngine;

namespace TM2D.Model.Tiles
{
    [CreateAssetMenu(fileName = "PrefabRuleTile", menuName = "TM2D/Model/Tiles/PrefabRuleTile")]
    public class PrefabRuleTile : RuleTile
    {
        [SerializeField] private Tile _prefab;

        public Tile Prefab => _prefab;
    }
}
