using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SerializableDictionary.Editor
{
    [CustomPropertyDrawer(typeof(ISerializableDictionary), true)]
    public class SerializableDictionaryDrawer : PropertyDrawer
    {
        private List<int> _openedKeys = new();
        
        public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(rect, label, property);
            
            if (!property.isExpanded)
            {
                property.isExpanded = EditorGUILayout.Foldout(property.isExpanded, label);
                EditorGUI.EndProperty();
                return;
            }

            property.isExpanded = EditorGUILayout.Foldout(property.isExpanded, label);

            EditorGUI.indentLevel++;

            SerializedProperty arraySizeProp = property.FindPropertyRelative("Array.size");
            EditorGUILayout.PropertyField(arraySizeProp);

            for (int i = 0; i < arraySizeProp.intValue; i++)
            {
                EditorGUILayout.PropertyField(property.GetArrayElementAtIndex(i), new GUIContent("Element " + i));
            }

            EditorGUI.indentLevel--;
            
            var keys = property.FindPropertyRelative("keys");
            var values = property.FindPropertyRelative("values");
            
            EditorGUI.EndProperty();
        }
        
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            // Get keys and values properties
            var keys = property.FindPropertyRelative("keys");
            var values = property.FindPropertyRelative("values");

            // Calculate the height of the property
            return EditorGUIUtility.singleLineHeight * (keys.arraySize + values.arraySize);
        }
    }
}
