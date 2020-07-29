using TM2D.ECS;
using TM2D.UI;
using UnityEngine;

namespace TM2D.Model.Components
{
    [CreateAssetMenu(fileName = "PassabilityState", menuName = "TM2D/Model/Components/PassabilityState")]
    public class PassabilityStateComponent : SOComponent, IUIComponent
    {
        [SerializeField] private bool _passability;

        [UIBool("Проходимость")]
        public bool Passability => _passability;
    }
}
