using System;
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
            var assetPath = AssetDatabase.GetAssetPath(selection);

            // Find the package name in the asset path. The returned path will be
            // something like:
            //
            // "Packages/my.package.name/path/to/asset"
            //
            // In order to get just the "my.package.name" part, we repeatedly strip the
            // last segment off the path until all that's left of the path is
            // "Packages". Once we hit that point, we know the last segment we pulled
            // off is the package name.
            var packageName = assetPath;
            var parentPath = assetPath;
            while (parentPath != "Packages")
            {
                packageName = Path.GetFileName(parentPath);
                parentPath = Path.GetDirectoryName(parentPath);

                // Ensure that we don't get stuck in an infinite loop if the player somehow clicks
                // this menu item when the selected item isn't under the Packages folder. This
                // *should* be setup so that EmbedPackageValidation() ensures that this can't
                // happen, but in case we have a logic error here we don't want to get stuck in a
                // loop since that will cause the editor to freeze.
                if (string.IsNullOrEmpty(parentPath))
                {
                    throw new ArgumentException(
                        $"Selected asset {assetPath} is not under Packages folder");
                }
            }

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

            // Get the path for the selected asset.
            var path = AssetDatabase.GetAssetPath(selection);

            // Find the root directory for the selected asset.
            var folder = path;
            while (true)
            {
                string temp = Path.GetDirectoryName(folder);
                if (string.IsNullOrEmpty(temp))
                {
                    break;
                }

                folder = temp;
            }

            // We only deal with direct folders under Packages/
            return folder == "Packages";
        }
    }

#endif
}
