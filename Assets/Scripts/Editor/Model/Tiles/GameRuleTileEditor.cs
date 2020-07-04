using TM2D.Model.Tiles;
using UnityEditor;

namespace TM2D.Editor.Model.Tiles
{
    [CustomEditor(typeof(GameRuleTile))]
    public class GameRuleTileEditor : RuleTileEditor
    {
        private SerializedProperty _tileData;

        private new void OnEnable()
        {
            _tileData = serializedObject.FindProperty(nameof(_tileData));
            base.OnEnable();
        }

        public override void OnInspectorGUI()
        {
            serializedObject.UpdateIfRequiredOrScript();
            EditorGUILayout.PropertyField(_tileData);
            serializedObject.ApplyModifiedPropertiesWithoutUndo();

            EditorGUILayout.Space(10);
            base.OnInspectorGUI();
        }
    }
}
