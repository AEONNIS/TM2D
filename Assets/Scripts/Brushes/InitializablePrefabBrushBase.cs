using System.Collections.Generic;
using TileMap2D.Model;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;

namespace TileMap2D.Brushes
{
    public class InitializablePrefabBrushBase : GridBrush
    {
        [SerializeField] private Vector3 _anchor = new Vector3(0.5f, 0.5f, 0.5f);

        private List<Initializable> _initializables;

        protected List<Initializable> GetInitializablesInCell(GridLayout grid, Transform parent, Vector3Int position)
        {
            parent.GetComponentsInChildren(true, _initializables);
            List<Initializable> results = new List<Initializable>();

            foreach (var initializable in _initializables)
            {
                if (position == grid.WorldToCell(initializable.transform.position))
                    results.Add(initializable);
            }

            return results;
        }

        protected void InstantiatePrefabInCell(GridLayout grid, GameObject brushTarget, Vector3Int position, Initializable prefab)
        {
            Initializable instance = (Initializable)PrefabUtility.InstantiatePrefab(prefab);
            if (instance != null)
            {
                Undo.MoveGameObjectToScene(instance.gameObject, brushTarget.scene, "Paint Prefabs");
                Undo.RegisterCreatedObjectUndo(instance, "Paint Prefabs");
                instance.transform.SetParent(brushTarget.transform);
                instance.transform.position = grid.LocalToWorld(grid.CellToLocalInterpolated(position + _anchor));
            }
        }
    }
}