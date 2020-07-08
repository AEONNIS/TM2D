using TM2D.ECS;
using UnityEngine;

namespace TM2D.Model.Components
{
    [CreateAssetMenu(fileName = "InfoData", menuName = "TM2D/Model/Components/InfoData")]
    public class InfoData : ScriptableObjectComponent
    {
        [SerializeField] private string _name;
        [TextArea(1, 5)]
        [SerializeField] private string _description;

        public string Name => _name;
        public string Description => _description;
    }
}
