using UnityEngine;

namespace TM2D.Model.Tiles
{
    [CreateAssetMenu(fileName = "TileData", menuName = "TM2D/Model/Tiles/TileData")]
    public class TileData : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private string _type;
        [SerializeField] private string _name;
        [TextArea(1, 5)]
        [SerializeField] private string _description;
        [SerializeField] private bool _passability;

        public string Id => _id;
        public string Type => _type;
        public string Name => _name;
        public string Description => _description;
        public bool Passability => _passability;
    }
}
