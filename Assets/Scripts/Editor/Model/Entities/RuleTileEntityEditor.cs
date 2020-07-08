using TM2D.Model.Entities;
using UnityEditor;

namespace TM2D.Editor.Model.Entities
{
    [CustomEditor(typeof(RuleTileEntity))]
    public class RuleTileEntityEditor : RuleTileEditor
    {
        private SerializedProperty _soComponents;

        private new void OnEnable()
        {
            _soComponents = serializedObject.FindProperty(nameof(_soComponents));
            base.OnEnable();
        }

        public override void OnInspectorGUI()
        {
            serializedObject.UpdateIfRequiredOrScript();
            EditorGUILayout.PropertyField(_soComponents);
            serializedObject.ApplyModifiedPropertiesWithoutUndo();

            EditorGUILayout.Space(10);
            base.OnInspectorGUI();
        }
    }
}
