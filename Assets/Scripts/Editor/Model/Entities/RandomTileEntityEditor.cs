using TM2D.Model.Entities;
using UnityEditor;
using UnityEngine.Tilemaps;

namespace TM2D.Editor.Model.Entities
{
    [CustomEditor(typeof(RandomTileEntity))]
    public class RandomTileEntityEditor : RandomTileEditor
    {
        private SerializedProperty _components;

        private new void OnEnable()
        {
            _components = serializedObject.FindProperty(nameof(_components));
            base.OnEnable();
        }

        public override void OnInspectorGUI()
        {
            serializedObject.UpdateIfRequiredOrScript();
            EditorGUILayout.PropertyField(_components);
            serializedObject.ApplyModifiedPropertiesWithoutUndo();

            EditorGUILayout.Space(10);
            base.OnInspectorGUI();
        }
    }
}
