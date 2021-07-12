using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace LocalizeURL.Editor
{
    [CustomPropertyDrawer(typeof(URLId), true)]
    public class URLIdDrawer : PropertyDrawer
    {
        private string[] keysArray;
        private int currentSelected = 0;

        private const float space = 22f;

        private Rect foldoutRect = new Rect();

        private float height;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            foldoutRect = new Rect();
            URLId target = (URLId)fieldInfo.GetValue(property.serializedObject.targetObject);

            EditorGUI.BeginProperty(position, label, property);
            foldoutRect = new Rect(position.x, position.y, position.width - 30, EditorGUIUtility.singleLineHeight);
            height = foldoutRect.y - EditorGUIUtility.singleLineHeight;
            property.isExpanded = EditorGUI.Foldout(foldoutRect, property.isExpanded, property.displayName);

            if (property.isExpanded)
            {
                foldoutRect.y += space;
                foldoutRect.x += space;

                List<string> keyList = new List<string>(URLData.DictionaryURL.Keys);

                if (keyList.Count == 0)
                {

                    EditorGUI.LabelField(foldoutRect, "No exists key values", EditorStyles.helpBox);

                    foldoutRect.y += space;
                    if (GUI.Button(foldoutRect, "Add Key..."))
                    {
                        LocalizeURLWindow.ShowWindow(1);
                    }
                    height = foldoutRect.y + space - height;
                    return;
                }

                keyList.Insert(0, "None");

                keysArray = keyList.ToArray();

                if (keyList.Contains(target.id))
                {
                    currentSelected = keyList.IndexOf(target.id);
                }

                
                EditorGUI.LabelField(foldoutRect, "Key:", EditorStyles.boldLabel);

                foldoutRect.y += space;
                currentSelected = EditorGUI.Popup(foldoutRect, "Select Key: ", currentSelected, keysArray);
                foldoutRect.y += space;
                if (GUI.Button(foldoutRect, "Add Key..."))
                {
                    LocalizeURLWindow.ShowWindow(1);
                }


                foldoutRect.y += space*1.7f;
                EditorGUI.LabelField(foldoutRect, "Params:", EditorStyles.boldLabel);
                bool customParams = property.FindPropertyRelative("customParams").boolValue;

                

                if (currentSelected != 0)
                {

                 
                    foldoutRect.y += space;
                   
                    EditorGUI.PropertyField(foldoutRect, property.FindPropertyRelative("customParams"));

                    if (customParams)
                    {
                        foldoutRect.y += space;
                        EditorGUI.PropertyField(foldoutRect, property.FindPropertyRelative("separatorParams"));


                        foldoutRect.y += space;
                        EditorGUI.PropertyField(foldoutRect, property.FindPropertyRelative("separatorKeyAndValue"));

                        foldoutRect.y += space;

                        SerializedProperty arrayProperty = property.FindPropertyRelative("urlParams");
                        var arrayRect = new Rect(foldoutRect.x, foldoutRect.y, foldoutRect.width, foldoutRect.height);

                        arrayRect.height = EditorGUI.GetPropertyHeight(arrayProperty);
             
                        EditorGUI.PropertyField(arrayRect, arrayProperty, true);

                        foldoutRect.y += arrayRect.height - 30;


                    }
                }

                

                if (currentSelected != 0)
                {
                    if (currentSelected >= keyList.Count)
                        currentSelected = keyList.Count - 1;
                    string key = keysArray[currentSelected];
                    property.FindPropertyRelative("id").stringValue = key;
                    property.serializedObject.ApplyModifiedProperties();

                    foldoutRect.y += space*2;


                    EditorGUI.LabelField(foldoutRect, "Previous URLs", EditorStyles.boldLabel);
                    
                         
                    foldoutRect.y += space;
                       
                    TextAreaStyles(ref foldoutRect, "Production URL:", URLData.DictionaryURL[key].production, false);

                    TextAreaStyles(ref foldoutRect, "Test URL:", URLData.DictionaryURL[key].test, false);


   
                    
                   
                    if (customParams)
                    {
                        foldoutRect.y += 20;
                        TextAreaStyles(ref foldoutRect, "URL Parms:", target.GetURL(), false);

                        foldoutRect.y += space*2;
                        
                    }
                }
                else
                {
                    property.FindPropertyRelative("id").stringValue = "";
                }

           
            }
            EditorGUI.EndProperty();
            height = foldoutRect.y - height;
            property.serializedObject.ApplyModifiedProperties();
        }
   
       private void TextAreaStyles(ref Rect rect, string name, string textContent, bool isEdit = true)
        {
            var areaStyle = new GUIStyle(EditorStyles.textArea);
            areaStyle.fixedHeight = 0;
            areaStyle.fixedHeight = areaStyle.CalcHeight(new GUIContent(textContent), rect.width);
            EditorGUI.LabelField(rect, name);
            rect.y += 20;

            if (isEdit)
            {
                EditorGUI.TextArea(rect, textContent, areaStyle);
            }
            else
            {
                EditorGUI.LabelField(rect, textContent, areaStyle);
            }

            areaStyle.fixedHeight = 0;
            float height = areaStyle.CalcHeight(new GUIContent(textContent), rect.width);

            rect.y += height;

        }

       public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return height;
        }
    }
}
