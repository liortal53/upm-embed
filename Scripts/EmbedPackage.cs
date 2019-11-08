using System.IO;
using UnityEditor.PackageManager;
using UnityEngine;

namespace UnityEditor.Extensions
{
    #if UNITY_2017_3_OR_NEWER
    
    /// <summary>
    /// Editor extension for embedding packages as a local copy in the project.
    /// This can be useful in case you want to modify the package's source code.
    /// </summary>
    public static class EmbedPackage
    {
        [MenuItem("Assets/Embed Package", false, 1000000)]
        private static void EmbedPackageMenuItem()
        {
            var selection = Selection.activeObject;
            var packageName = Path.GetFileName(AssetDatabase.GetAssetPath(selection));

            Debug.Log($"Embedding package '{packageName}' into the project.");

            Client.Embed(packageName);

            AssetDatabase.Refresh();
        }

        [MenuItem("Assets/Embed Package", true)]
        private static bool EmbedPackageValidation()
        {
            var selection = Selection.activeObject;

            if (selection == null)
            {
                return false;
            }

            var path = AssetDatabase.GetAssetPath(selection);
            var folder = Path.GetDirectoryName(path);
            
            // We only deal with direct folders under Packages/
            return folder == "Packages";
        }
    }
    
    #endif
}