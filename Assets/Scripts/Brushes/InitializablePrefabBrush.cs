using System.Linq;
using TileMap2D.Model;
using UnityEditor;
using UnityEngine;

namespace TileMap2D.Brushes
{
    [CreateAssetMenu(fileName = "NewInitializablePrefabBrush", menuName = "TileMap2D/Brushes/InitializablePrefabBrush")]
    [CustomGridBrush(false, true, false, "Initializable Prefab Brush")]
    public class InitializablePrefabBrush : InitializablePrefabBrushBase
    {
        public bool _eraseAnyObjects;

        [SerializeField] private Initializable _initializable;

        /// <summary>
        /// Paints GameObject from containg Prefab into a given position within the selected layers.
        /// The InitializablePrefabBrush overrides this to provide Prefab painting functionality.
        /// </summary>
        /// <param name="grid">Grid used for layout.</param>
        /// <param name="brushTarget">Target of the paint operation. By default the currently selected GameObject.</param>
        /// <param name="position">The coordinates of the cell to paint data to.</param>
        public override void Paint(GridLayout grid, GameObject brushTarget, Vector3Int position)
        {
            // Do not allow editing palettes
            if (brushTarget.layer == 31 || brushTarget == null)
            {
                return;
            }

            var objectsInCell = GetInitializablesInCell(grid, brushTarget.transform, position);
            var existPrefabObjectInCell = objectsInCell.Any(objectInCell => PrefabUtility.GetCorrespondingObjectFromSource(objectInCell) == _initializable);

            if (!existPrefabObjectInCell)
            {
                base.InstantiatePrefabInCell(grid, brushTarget, position, _initializable);
            }
        }

        /// <summary>
        /// If "Erase Any Objects" is true, erases any GameObjects that are in a given position within the selected layers.
        /// If "Erase Any Objects" is false, erases only GameObjects that are created from owned Prefab in a given position within the selected layers.
        /// The InitializablePrefabBrush overrides this to provide Prefab erasing functionality.
        /// </summary>
        /// <param name="grid">Grid used for layout.</param>
        /// <param name="brushTarget">Target of the erase operation. By default the currently selected GameObject.</param>
        /// <param name="position">The coordinates of the cell to erase data from.</param>
        public override void Erase(GridLayout grid, GameObject brushTarget, Vector3Int position)
        {
            if (brushTarget.layer == 31 || brushTarget.transform == null)
            {
                return;
            }

            foreach (var objectInCell in GetInitializablesInCell(grid, brushTarget.transform, position))
            {
                if (_eraseAnyObjects || PrefabUtility.GetCorrespondingObjectFromSource(objectInCell) == _initializable)
                {
                    Undo.DestroyObjectImmediate(objectInCell);
                }
            }
        }
    }
}
