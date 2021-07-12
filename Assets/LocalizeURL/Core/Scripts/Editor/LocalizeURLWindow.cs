using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace LocalizeURL.Editor
{
    public class LocalizeURLWindow : EditorWindow
    {
        [MenuItem("Window/Localize URL")]
        public static LocalizeURLWindow ShowWindow()
        {
            var a = GetWindow<LocalizeURLWindow>(false, "Localize URL", true);
            a.maximized = true;
            a.position = new Rect(200, 200, 500, 500);
            a.minSize = new Vector2(500, 500);

            return a;
        }

        public static LocalizeURLWindow ShowWindow(int currentTab)
        {
            var w = ShowWindow();

            w.currentTab = currentTab;

            return w;
        }

        private Vector2 scrollPosition;
        private SerializedObject serializedWindow;
        private SerializedObject serializeObject;

        private SerializedProperty serializedDictionary;

        private string[] myTabs = new string[] { "Geral", "Values" };


        private int currentTab;
        private void OnEnable()
        {

            if (URLData.Instance == null)
            {
                URLData asset = CreateInstance<URLData>();
                string path = AssetDatabase.GenerateUniqueAssetPath(System.IO.Path.Combine("Assets", "LocalizeURL", "Core", "Resources", "URL Data.asset"));
                AssetDatabase.CreateAsset(asset, path);
                AssetDatabase.SaveAssets();

                EditorUtility.FocusProjectWindow();

                Selection.activeObject = asset;
            }

            serializedWindow = new SerializedObject(this);

            serializeObject = new SerializedObject(URLData.Instance);

            serializedDictionary = serializeObject.FindProperty("_dictionaryURL");
           
        }
        private void OnGUI()
        {
            
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
            EditorGUILayout.BeginVertical();
            serializeObject.Update();
            serializedWindow.Update();
            EditorGUILayout.Space();
            currentTab = GUILayout.Toolbar(currentTab, myTabs);

            EditorGUILayout.Space(30);
            switch (currentTab)
            {
                case 0:
                    GeralTab();
                    break;
                case 1:
                    ValuesTab();
                    break;        
            }

            EditorGUILayout.EndVertical();
            EditorGUILayout.Space(30);
            EditorGUILayout.EndScrollView();

            serializeObject.ApplyModifiedProperties();
            serializedWindow.ApplyModifiedProperties();
        }


        private void GeralTab()
        {
            EditorGUILayout.BeginHorizontal();

            URLData.TestMode = EditorGUILayout.Toggle("Test Mode:",URLData.TestMode);

            EditorGUILayout.EndHorizontal();
        }

        private void ValuesTab()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(serializedDictionary, true);
            EditorGUILayout.EndHorizontal();
        }
    }
}
