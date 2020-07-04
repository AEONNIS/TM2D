using TM2D.Model.Brushes;
using UnityEditor;
using UnityEditor.Tilemaps;

namespace TM2D.Editor.Model.Brushes
{
    [CustomEditor(typeof(PrefabTileBrush_))]
    public class PrefabTileBrush_Editor : GridBrushEditor
    {
        private SerializedObject _serializedObject;
        private SerializedProperty _tile;
        private SerializedProperty _anchor;

        private PrefabTileBrush_ _prefabTileBrush => target as PrefabTileBrush_;

        protected override void OnEnable()
        {
            base.OnEnable();
            _serializedObject = new SerializedObject(target);
            _tile = _serializedObject.FindProperty(nameof(_tile));
            _anchor = _serializedObject.FindProperty(nameof(_anchor));
        }

        public override void OnPaintInspectorGUI()
        {
            _serializedObject.UpdateIfRequiredOrScript();
            EditorGUILayout.PropertyField(_tile, true);
            EditorGUILayout.PropertyField(_anchor);
            _prefabTileBrush.EraseAnyObjects = EditorGUILayout.Toggle(nameof(_prefabTileBrush.EraseAnyObjects),
                                                                             _prefabTileBrush.EraseAnyObjects);
            _serializedObject.ApplyModifiedPropertiesWithoutUndo();
        }
    }
}