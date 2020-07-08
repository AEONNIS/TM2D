using UnityEngine;
using static TM2D.Infrastructure.Inputs.Input;

namespace TM2D.Infrastructure.Inputs
{
    public class InputController : MonoBehaviour
    {
        private Input _input;

        public PlayerActions Player => _input.Player;

        #region Unity
        private void Awake() => _input = new Input();

        private void OnEnable() => _input.Enable();

        private void OnDisable() => _input.Disable();
        #endregion
    }
}
