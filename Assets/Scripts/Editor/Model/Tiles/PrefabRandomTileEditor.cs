using TM2D.Model.Tiles;
using UnityEditor;
using UnityEngine.Tilemaps;

namespace TM2D.Editor.Model.Tiles
{
    [CustomEditor(typeof(PrefabRandomTile))]
    public class PrefabRandomTileEditor : RandomTileEditor
    {
        private SerializedProperty _prefab;

        private new void OnEnable()
        {
            _prefab = serializedObject.FindProperty(nameof(_prefab));
            base.OnEnable();
        }

        public override void OnInspectorGUI()
        {
            serializedObject.UpdateIfRequiredOrScript();
            EditorGUILayout.PropertyField(_prefab);
            serializedObject.ApplyModifiedPropertiesWithoutUndo();

            EditorGUILayout.Space(10);
            base.OnInspectorGUI();
        }
    }
}
