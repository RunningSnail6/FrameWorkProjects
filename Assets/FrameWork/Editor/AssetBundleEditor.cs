using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

public class AssetBundleEditor 
{
    [MenuItem("Itools/BuildeAssetBundle")]
    public  static void BuildeAssetBundle()
    {
        string outPath = Application.dataPath + "/AssetBuldle";

        BuildPipeline.BuildAssetBundles(outPath,0,EditorUserBuildSettings.activeBuildTarget);
    }

    [MenuItem("Itools/MarkAssetBundle")]
    public static void MarkAssetBundle()
    {
        AssetDatabase.RemoveUnusedAssetBundleNames();//把没用的标签移除了

        string path = Application.dataPath + "Art/Scences/";
        DirectoryInfo dir = new DirectoryInfo(path);
        FileSystemInfo[] fileInfor = dir.GetFileSystemInfos();
        for(int i = 0;i<fileInfor.Length;i++)
        {
            FileSystemInfo tmpFile = fileInfor[i];
            if(tmpFile is DirectoryInfo)
            {
                string tmpPath = Path.Combine(path, tmpFile.Name);
                ScnecenOverView(tmpPath);
            }
        }
    }

    //对整个场景遍历
    public static void ScnecenOverView(string scencePath)
    {
        string textFileName = "Record.txt";
        string tmpPath = scencePath + textFileName;
        FileStream fs = new FileStream(tmpPath, FileMode.OpenOrCreate);//对文件进行打开操作，如果没有就创建
        StreamWriter bw = new StreamWriter(fs);
        //存储对应关系
        Dictionary<string, string> readDict = new Dictionary<string, string>();
        ChangerHead(tmpPath, readDict);
        bw.Close();
        fs.Close();
    }

    //截取 相对路径  (D:/ToLuFish/Assets/Art/Scences/   ScenceOne)
    //截取scenceOne/load/
    /// <summary>
    /// 
    /// </summary>
    /// <param name="fullPath"></param>
    /// <param name="theWriter">文本记录</param>
    public static void ChangerHead(string fullPath,Dictionary<string,string> theWriter)
    {
        //得到的是D:/ToLuFish/.......总长度
        int tmpCount = fullPath.IndexOf("Assets");
        int tmpLength = fullPath.Length;

        //Assets/Art/Scences/   ScenceOne
        string replacePath = fullPath.Substring(tmpCount, tmpLength - tmpCount);
        DirectoryInfo dir = new DirectoryInfo(fullPath);

        if(dir != null)
        {
            ListFiles(dir, replacePath, theWriter);
        }
        else
        {
            Debug.Log("this path is not exit");
        }
    }

    //遍历场景中每个功能文件夹
    public static void ListFiles(FileSystemInfo info,string replacePath,Dictionary<string,string> theWriter)
    {
        if(!info.Exists)
        {
            Debug.Log("is not exit");
            return;
        }
        DirectoryInfo dir = info as DirectoryInfo;
        FileSystemInfo[] files = dir.GetFileSystemInfos();
        for(int i = 0;i<files.Length;i++)
        {
            FileInfo file = files[i] as FileInfo;

            if (files != null)//对于文件的操作
            {

            }
            else//对目录的操作
            {
                ListFiles(files[i], replacePath, theWriter);
            }
        }
    }


    //计算mart标记值等于多少
    public static string GetBundlePath(FileInfo file,string replacePath)
    {
        return null;
    }
    //改变物体的tag
    public static void ChangerMark(FileInfo tmpFile,string replacePath,Dictionary<string,string> theWriter)
    {
        if(tmpFile.Extension == "meta")
        {
            return;
        }

        string markStr = GetBundlePath(tmpFile, replacePath);
    }
    
}
