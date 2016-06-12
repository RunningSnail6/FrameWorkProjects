using UnityEngine;
using System.Collections;
using UnityEditor;

public class AssetBundleEditor 
{
    [MenuItem("Itools/BuildeAssetBundle")]
    public  static void BuildeAssetBundle()
    {
        string outPath = Application.dataPath + "/AssetBuldle";

        BuildPipeline.BuildAssetBundle(outPath,0,EditorUserBuildSettings.activeBuildTarget);
    }
}
