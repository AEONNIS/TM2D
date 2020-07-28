using TM2D.Model.Maps;
using UnityEngine;

namespace TM2D.UI
{
    public class UserInterface : MonoBehaviour
    {
        [SerializeField] private Map _map;
        [SerializeField] private InfoPanel _infoPanel;

        public void PresentEntitiesInfoIn(Vector3Int cursorPosition) => _infoPanel.Present(cursorPosition);

        #region Unity
        private void Awake() => _infoPanel.Init();
        #endregion
    }
}
