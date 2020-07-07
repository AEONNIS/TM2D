using UnityEngine;

namespace TM2D.Model.Inputs
{
    public class InputController : MonoBehaviour
    {
        private Input _input;

        public Input Input => _input;

        #region Unity
        private void Awake() => _input = new Input();

        private void OnEnable() => _input.Enable();

        private void OnDisable() => _input.Disable();
        #endregion
    }
}
