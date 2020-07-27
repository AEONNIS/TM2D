using TM2D.ECS;
using TM2D.UI;
using UnityEngine;

namespace TM2D.Model.Components
{
    [CreateAssetMenu(fileName = "InfoData", menuName = "TM2D/Model/Components/InfoData")]
    public class InfoData : SOComponent, IUIComponent
    {
        [SerializeField] private string _name;
        [TextArea(1, 5)]
        [SerializeField] private string _description;

        [UIText("Имя")]
        public string Name => _name;
        [UIText("Описание")]
        public string Description => _description;
    }
}
