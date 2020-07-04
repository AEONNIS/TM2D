using TM2D.Model.Tiles;
using UnityEditor;

namespace TM2D.Editor.Model.Tiles
{
    [CustomEditor(typeof(PrefabRuleTile))]
    public class PrefabRuleTileEditor : RuleTileEditor
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
