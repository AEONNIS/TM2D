using TM2D.ECS;
using UnityEngine;

namespace TM2D.UI
{
    public class InfoPanel : MonoBehaviour
    {
        [SerializeField] private InfoModule _module;

        public void Present(IEntity entity)
        {
            _module.Present(entity);
        }
    }
}
