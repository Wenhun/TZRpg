using System;
using UnityEngine;
using UnityEditor;

namespace RPG.Editor
{
    public class CreateAssetBundle
    {
        [MenuItem("Assets/Create Assets Bundles")]
        private static void BuildAssAssetBundles()
        {
            string assetBundleDirectoryPath = Application.dataPath + "/../Assets/StreamingAssets";
            try
            {
                BuildPipeline.BuildAssetBundles(assetBundleDirectoryPath, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
            }
            catch (Exception e)
            {
                Debug.LogWarning(e);
            }
        }
    }

}