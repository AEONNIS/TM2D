using TM2D.ECS;
using TM2D.UI;
using UnityEngine;

namespace TM2D.Model.Components
{
    [CreateAssetMenu(fileName = "DescriptionData", menuName = "TM2D/Model/Components/DescriptionData")]
    public class DescriptionDataComponent : SOComponent, IUIComponent
    {
        [TextArea(1, 5)]
        [SerializeField] private string _description;

        [UIText("Описание")]
        public string Description => _description;
    }
}
