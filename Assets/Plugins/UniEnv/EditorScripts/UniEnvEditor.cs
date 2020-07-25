using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace UniEnvs
{
    [CustomEditor(typeof(UniEnv))]
    public class UniEnvEditor : Editor
    {
        private string overwriteJson = "";
        private bool showWarning = false;
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GUILayout.Space(10);

            var prop = target as UniEnv;
            
            GUILayout.Label("Config Text");
            GUILayout.BeginHorizontal();
            var json = GUILayout.TextArea(prop.ToString(),GUILayout.MinHeight(100));
            GUILayout.EndHorizontal();
            
            GUILayout.Space(10);
            
            GUILayout.Label("Overwrite Config");
            overwriteJson = GUILayout.TextArea(overwriteJson, GUILayout.MinHeight(100));
            if(GUILayout.Button("Over write", GUILayout.Width(100), GUILayout.Height(30)))
            {
                prop.OverWriteConfig(overwriteJson);
                overwriteJson = string.Empty;
            }

            GUILayout.Space(10);

            if (showWarning)
            {
                EditorGUILayout.HelpBox("'Env.assets' and 'Env.assets.meta' aren't ignored. It isn't recommended that include env file to product code.", MessageType.Warning);
                if (GUILayout.Button("Add ignore", GUILayout.Width(100)))
                {
                    File.AppendAllLines(gitIgnorePath, new []
                    {
                        "",
                        envPath,
                        envMetaPath
                    });
                    
                    showWarning = IsGitIgnoreExists() && !IsIgnoreEnvFile();
                };
            }
        }

        public void OnEnable()
        {
            showWarning = IsGitIgnoreExists() && !IsIgnoreEnvFile();
        }

        private static string gitIgnorePath => "Assets/../.gitignore";
        private static string envPath => "Assets/Plugins/UniEnv/Env.asset";
        private static string envMetaPath => "Assets/Plugins/UniEnv/Env.asset.meta";
        
        private static bool IsGitIgnoreExists() => File.Exists(gitIgnorePath);

        private static bool IsIgnoreEnvFile()
        {
            var text = File.ReadAllText(gitIgnorePath);
            
            return text.Contains(envPath) && 
                   text.Contains(envMetaPath);
        }
    }
}