using System;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace UniEnvs
{
    /// <summary>
    /// UniEnv is entry point to access environment values
    /// </summary>
    [Serializable]
    public class UniEnv : ScriptableObject
    {
        [SerializeField] 
        private Config config = default;

        public static Config Config => LoadEnv().config;
        private static string Path => "Assets/Plugins/UniEnv/Env.asset";
        private static UniEnv LoadEnv() => AssetDatabase.LoadAssetAtPath<UniEnv>(Path);
        
        [MenuItem("Assets/UniEnv/Env")]
        internal static void CreateAsset()
        {
            var obj = ScriptableObject.CreateInstance<UniEnv>();
            var d = new FileInfo(Path).Directory;
            if (!d.Exists)
            {
                d.Create();
            }
            AssetDatabase.CreateAsset(obj, Path);
            EditorUtility.SetDirty (obj);
        }

        /// <summary>
        /// Export .env style texts as following
        /// Key1=Value1
        /// Key2=Value2
        /// Key3=Value3
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var builder = new StringBuilder();

            foreach (var c in config)
            {
                if(string.IsNullOrEmpty(c.Key) || string.IsNullOrEmpty(c.Value))
                   continue;
                   
                builder.AppendLine($"{c.Key}={c.Value}");
            }

            return builder.ToString();
        }
        
        /// <summary>
        /// Since this method is for editor utility, access level is internal.
        /// TODO: Validate input configText strictly
        /// </summary>
        /// <param name="configText"></param>
        internal void OverWriteConfig(string configText)
        {
            var reader = new StringReader(configText);
            var newConfig = new Config();
            
            while (reader.Peek() > -1)
            {
                var line = reader.ReadLine();
                var key_vals = line?.Split(new[]{"="}, 2, StringSplitOptions.None);
                
                newConfig.Add(key_vals[0], key_vals[1]);
            }

            config.Clear();
            config = newConfig;
        }
    }
}
