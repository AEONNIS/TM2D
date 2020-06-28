using TileMap2D.Brushes;
using UnityEditor;
using UnityEditor.Tilemaps;

namespace TileMap2D.Editor.Brushes
{
    [CustomEditor(typeof(InitializablePrefabBrushBase))]
    public class InitializablePrefabBrushBaseEditor : GridBrushEditor
    {
        private SerializedProperty _anchor;
        protected SerializedObject _serializedObject;

        protected override void OnEnable()
        {
            base.OnEnable();
            _serializedObject = new SerializedObject(target);
            _anchor = _serializedObject.FindProperty("_anchor");
        }

        public override void OnPaintInspectorGUI()
        {
            _serializedObject.UpdateIfRequiredOrScript();
            EditorGUILayout.PropertyField(_anchor);
            _serializedObject.ApplyModifiedPropertiesWithoutUndo();
        }
    }
}