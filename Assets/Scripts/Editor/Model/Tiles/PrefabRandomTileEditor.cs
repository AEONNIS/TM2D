using TM2D.Model.Tiles;
using UnityEditor;
using UnityEngine.Tilemaps;

namespace TM2D.Editor.Model.Tiles
{
    [CustomEditor(typeof(PrefabRandomTile))]
    public class PrefabRandomTileEditor : RandomTileEditor
    {
        private SerializedObject _prefabTile;
        private SerializedProperty _prefab;

        private new void OnEnable()
        {
            _prefabTile = new SerializedObject(target);
            _prefab = _prefabTile.FindProperty(nameof(_prefab));
            base.OnEnable();
        }

        public override void OnInspectorGUI()
        {
            _prefabTile.UpdateIfRequiredOrScript();
            EditorGUILayout.PropertyField(_prefab);
            _prefabTile.ApplyModifiedPropertiesWithoutUndo();

            EditorGUILayout.Space(10);
            base.OnInspectorGUI();
        }
    }
}
