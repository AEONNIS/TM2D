//using System.Collections.Generic;
//using System.Linq;
//using TM2D.Model;
//using UnityEditor;
//using UnityEditor.Tilemaps;
//using UnityEngine;

//namespace TM2D.Brushes
//{
//    [CreateAssetMenu(fileName = "TilePrefabBrush", menuName = "TileMap2D/Brushes/Tile Prefab Brush")]
//    [CustomGridBrush(false, true, false, "Tile Prefab Brush")]
//    public class TilePrefabBrush : GridBrush
//    {
//        [SerializeField] private Initializable _prefab;
//        [SerializeField] private Vector3 _anchor = new Vector3(0.5f, 0.5f, 0.5f);

//        public bool EraseAnyObjects { get; set; }

//        public override void Paint(GridLayout grid, GameObject brushTarget, Vector3Int position)
//        {
//            if (brushTarget.layer == 31 || brushTarget == null)
//                return;

//            if (!GetTilePrefabsInCell(grid, brushTarget.transform, position).Any(tilePrefab =>
//                                      PrefabUtility.GetCorrespondingObjectFromSource(tilePrefab) == _prefab))
//                InstantiatePrefabInCell(grid, brushTarget, position, _prefab);
//        }

//        public override void Erase(GridLayout grid, GameObject brushTarget, Vector3Int position)
//        {
//            if (brushTarget.layer == 31 || brushTarget.transform == null)
//                return;

//            foreach (var tilePrefab in GetTilePrefabsInCell(grid, brushTarget.transform, position))
//            {
//                if (EraseAnyObjects || PrefabUtility.GetCorrespondingObjectFromSource(tilePrefab) == _prefab)
//                    Undo.DestroyObjectImmediate(tilePrefab.gameObject);
//            }
//        }

//        private List<Initializable> GetTilePrefabsInCell(GridLayout grid, Transform parent, Vector3Int position)
//        {
//            List<Initializable> results = new List<Initializable>();
//            List<Initializable> allTilePrefabs = new List<Initializable>();
//            parent.GetComponentsInChildren(true, allTilePrefabs);

//            foreach (var tilePrefab in allTilePrefabs)
//            {
//                if (position == grid.WorldToCell(tilePrefab.transform.position))
//                    results.Add(tilePrefab);
//            }

//            return results;
//        }

//        private void InstantiatePrefabInCell(GridLayout grid, GameObject brushTarget, Vector3Int position, Initializable prefab)
//        {
//            Initializable instance = (Initializable)PrefabUtility.InstantiatePrefab(prefab);
//            if (instance != null)
//            {
//                Undo.MoveGameObjectToScene(instance.gameObject, brushTarget.scene, "Paint Tile Prefab");
//                Undo.RegisterCreatedObjectUndo(instance.gameObject, "Paint Tile Prefab");
//                instance.transform.SetParent(brushTarget.transform);
//                instance.transform.position = grid.LocalToWorld(grid.CellToLocalInterpolated(position + _anchor));
//                instance.Init();
//            }
//        }
//    }
//}