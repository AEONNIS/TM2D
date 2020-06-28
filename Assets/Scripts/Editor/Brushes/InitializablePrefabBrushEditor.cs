using TileMap2D.Brushes;
using UnityEditor;

namespace TileMap2D.Editor.Brushes
{
    /// <summary>
    /// The Brush Editor for a Prefab Brush.
    /// </summary>
    [CustomEditor(typeof(InitializablePrefabBrush))]
    public class InitializablePrefabBrushEditor : InitializablePrefabBrushBaseEditor
    {
        private InitializablePrefabBrush prefabBrush => target as InitializablePrefabBrush;
        private SerializedProperty m_Prefab;

        protected override void OnEnable()
        {
            base.OnEnable();
            m_Prefab = _serializedObject.FindProperty(nameof(m_Prefab));
        }

        /// <summary>
        /// Callback for painting the inspector GUI for the InitializablePrefabBrush in the Tile Palette.
        /// The InitializablePrefabBrush Editor overrides this to have a custom inspector for this Brush.
        /// </summary>
        public override void OnPaintInspectorGUI()
        {
            base.OnPaintInspectorGUI();
            _serializedObject.UpdateIfRequiredOrScript();
            EditorGUILayout.PropertyField(m_Prefab, true);
            prefabBrush._eraseAnyObjects = EditorGUILayout.Toggle("Erase Any Objects", prefabBrush._eraseAnyObjects);
            _serializedObject.ApplyModifiedPropertiesWithoutUndo();
        }
    }
}
