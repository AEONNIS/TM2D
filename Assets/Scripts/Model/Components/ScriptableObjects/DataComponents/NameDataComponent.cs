using TM2D.ECS;
using TM2D.UI;
using UnityEngine;

namespace TM2D.Model.Components
{
    [CreateAssetMenu(fileName = "NameData", menuName = "TM2D/Model/Components/NameData")]
    public class NameDataComponent : SOComponent, IUIComponent
    {
        [SerializeField] private string _name;

        [UIString("Название")]
        public string Name => _name;
    }
}
