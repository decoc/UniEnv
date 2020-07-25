using UnityEditor;

namespace UniEnvs
{
    /// <summary>
    /// This class create Env.asset automatically when complete import package. 
    /// </summary>
    [InitializeOnLoad]
    public static class UniEnvPackageImporter
    {
        static UniEnvPackageImporter()
        {
            AssetDatabase.importPackageCompleted += ImportCompleted;
        }

        private static void ImportCompleted(string packagename)
        {
            if(packagename.Contains("UniEnv"))
            {
                UniEnv.CreateAsset();
            }
        }
    }
}