using UnityEngine;
using UnityEditor;
using System.IO;

public class CreateProjectFolders
{
    [MenuItem("Tools/Create Project Folders")]
    static void CreateFolders()
    {
        string[] folders = {
            "Assets/Project/Managers",
            "Assets/Project/Models",
            "Assets/Project/ViewModels",
            "Assets/Project/Views",
            "Assets/Project/Installers",
            "Assets/Project/Services",
            "Assets/Project/Utils",
            "Assets/Project/Configs",
            "Assets/XR/Interaction",
            "Assets/XR/Simulation",
            "Assets/XR/Debug",
            "Assets/Shaders",
            "Assets/Resources",
            "Assets/Scenes",
            "Assets/Tests"
        };

        foreach (var folder in folders)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
                Debug.Log("Created: " + folder);
            }
        }

        AssetDatabase.Refresh();
    }
}
