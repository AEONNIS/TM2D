using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TM2D.Model.Brushes
{
    [CreateAssetMenu(fileName = "PrefabTileBrush", menuName = "TM2D/Model/Brushes/PrefabTileBrush")]
    [CustomGridBrush(false, true, false, "PrefabTileBrush")]
    public class PefabTileBrush : GridBrush
    {
        [SerializeField] private Vector3 _anchor = new Vector3(0.5f, 0.5f, 0.5f);

        public override void Paint(GridLayout gridLayout, GameObject brushTarget, Vector3Int position)
        {
            if (brushTarget == null)
                return;

            Tilemap map = brushTarget.GetComponent<Tilemap>();
            if (map == null)
                return;

            Vector3Int min = position - pivot;
            BoundsInt bounds = new BoundsInt(min, size);
        }
    }
}