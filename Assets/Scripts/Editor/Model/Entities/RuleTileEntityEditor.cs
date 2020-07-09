using TM2D.Model.Entities;
using UnityEditor;

namespace TM2D.Editor.Model.Entities
{
    [CustomEditor(typeof(RuleTileEntity))]
    public class RuleTileEntityEditor : RuleTileEditor
    {
        private SerializedProperty _componentsContainer;

        private new void OnEnable()
        {
            _componentsContainer = serializedObject.FindProperty(nameof(_componentsContainer));
            base.OnEnable();
        }

        public override void OnInspectorGUI()
        {
            serializedObject.UpdateIfRequiredOrScript();
            EditorGUILayout.PropertyField(_componentsContainer);
            serializedObject.ApplyModifiedPropertiesWithoutUndo();

            EditorGUILayout.Space(10);
            base.OnInspectorGUI();
        }
    }
}
