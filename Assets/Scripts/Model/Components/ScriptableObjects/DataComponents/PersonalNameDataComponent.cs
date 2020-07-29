using TM2D.ECS;
using TM2D.UI;
using UnityEngine;

namespace TM2D.Model.Components
{
    [CreateAssetMenu(fileName = "PersonalNameData", menuName = "TM2D/Model/Components/PersonalNameData")]
    public class PersonalNameDataComponent : SOComponent, IUIComponent
    {
        [SerializeField] private string _name;

        [UIText("Имя")]
        public string Name => _name;
    }
}
