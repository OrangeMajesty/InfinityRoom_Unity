using System;
using UnityEngine;
#if UNITY_EDITOR
using System.Linq;
using UnityEditor;
#endif


/// <summary>
/// Кастомный атрибут для редактора.
/// Выводит перечисления в виде массива.
/// </summary>
public class ArrayByEnumAttribute : PropertyAttribute
{
    public readonly string[] Names;

    public ArrayByEnumAttribute(Type enumType)
    {
        Names = Enum.GetNames(enumType);
    }
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(ArrayByEnumAttribute))]
public class ArrayByEnumAttributeDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, label);
    }
    public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(rect, label, property);
        try
        {
            string[] names = ((ArrayByEnumAttribute)attribute).Names;

            string path    = property.propertyPath;
            string arrPath = path.Substring(0, path.LastIndexOf('.'));
            var arrProp = property.serializedObject.FindProperty(arrPath);
            
            if (arrProp.arraySize < names.Length)
                arrProp.arraySize = names.Length;

            int elPos  = int.Parse(path.Split('[').LastOrDefault().TrimEnd(']'));
            EditorGUI.PropertyField(rect, property, new GUIContent(ObjectNames.NicifyVariableName(names[elPos])), true);
        }
        catch
        {
            EditorGUI.PropertyField(rect, property, new GUIContent("none"), true);
        }
        
        EditorGUI.EndProperty();
    }
}
#endif