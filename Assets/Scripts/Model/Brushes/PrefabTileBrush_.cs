using System.Collections.Generic;
using System.Linq;
using TM2D.Model.Tiles;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;

namespace TM2D.Model.Brushes
{
    [CreateAssetMenu(fileName = "PrefabTileBrush_", menuName = "TM2D/Model/Brushes/PrefabTileBrush_")]
    [CustomGridBrush(false, true, false, "PrefabTileBrush_")]
    public class PrefabTileBrush_ : GridBrush
    {
        [SerializeField] private Tile _tile;
        [SerializeField] private Vector3 _anchor = new Vector3(0.5f, 0.5f, 0.5f);

        public bool EraseAnyObjects { get; set; }

        public override void Paint(GridLayout grid, GameObject brushTarget, Vector3Int position)
        {
            if (brushTarget.layer == 31 || brushTarget == null)
                return;

            if (!GetTilePrefabsInCell(grid, brushTarget.transform, position).Any(tilePrefab =>
                                      PrefabUtility.GetCorrespondingObjectFromSource(tilePrefab) == _tile))
                InstantiatePrefabInCell(grid, brushTarget, position, _tile);
        }

        public override void Erase(GridLayout grid, GameObject brushTarget, Vector3Int position)
        {
            if (brushTarget.layer == 31 || brushTarget.transform == null)
                return;

            foreach (var tilePrefab in GetTilePrefabsInCell(grid, brushTarget.transform, position))
            {
                if (EraseAnyObjects || PrefabUtility.GetCorrespondingObjectFromSource(tilePrefab) == _tile)
                    Undo.DestroyObjectImmediate(tilePrefab.gameObject);
            }
        }

        private List<Tile> GetTilePrefabsInCell(GridLayout grid, Transform parent, Vector3Int position)
        {
            List<Tile> results = new List<Tile>();
            List<Tile> allTilePrefabs = new List<Tile>();
            parent.GetComponentsInChildren(true, allTilePrefabs);

            foreach (var tilePrefab in allTilePrefabs)
            {
                if (position == grid.WorldToCell(tilePrefab.transform.position))
                    results.Add(tilePrefab);
            }

            return results;
        }

        private void InstantiatePrefabInCell(GridLayout grid, GameObject brushTarget, Vector3Int position, Tile tile)
        {
            Tile instance = (Tile)PrefabUtility.InstantiatePrefab(tile);
            if (instance != null)
            {
                Undo.MoveGameObjectToScene(instance.gameObject, brushTarget.scene, "Paint Prefab Tile");
                Undo.RegisterCreatedObjectUndo(instance.gameObject, "Paint Prefab Tile");
                instance.transform.SetParent(brushTarget.transform);
                instance.transform.position = grid.LocalToWorld(grid.CellToLocalInterpolated(position + _anchor));
            }
        }
    }
}