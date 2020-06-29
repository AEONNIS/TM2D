//using TM2D.Brushes;
//using UnityEditor;
//using UnityEditor.Tilemaps;

//namespace TM2D.Editor.Brushes
//{
//    [CustomEditor(typeof(TilePrefabBrush))]
//    public class TilePrefabBrushEditor : GridBrushEditor
//    {
//        private SerializedObject _serializedObject;
//        private SerializedProperty _prefab;
//        private SerializedProperty _anchor;

//        private TilePrefabBrush _tilePrefabBrush => target as TilePrefabBrush;

//        protected override void OnEnable()
//        {
//            base.OnEnable();
//            _serializedObject = new SerializedObject(target);
//            _prefab = _serializedObject.FindProperty(nameof(_prefab));
//            _anchor = _serializedObject.FindProperty(nameof(_anchor));
//        }

//        public override void OnPaintInspectorGUI()
//        {
//            _serializedObject.UpdateIfRequiredOrScript();
//            EditorGUILayout.PropertyField(_prefab, true);
//            EditorGUILayout.PropertyField(_anchor);
//            _tilePrefabBrush.EraseAnyObjects = EditorGUILayout.Toggle(nameof(_tilePrefabBrush.EraseAnyObjects),
//                                                                             _tilePrefabBrush.EraseAnyObjects);
//            _serializedObject.ApplyModifiedPropertiesWithoutUndo();
//        }
//    }
//}