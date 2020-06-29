using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //Added

public static class SaveSystem
{
    // You could change "Application.dataPath" --> "Application.persistentDataPath"
    public static readonly string SAVE_FOLDER = Path.Combine(Application.dataPath, "Save");
    
    public static void Init()
    {
        if (!Directory.Exists(SAVE_FOLDER))
        {
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }

    public static void Save(string saveString)
    {
        File.WriteAllText(Path.Combine(SAVE_FOLDER,"save.json"), saveString);
    }

    public static bool SaveFound()
    {
        if (File.Exists(Path.Combine(SAVE_FOLDER, "save.json")))
        {
            return true;
        }
        return false;
    }

    public static string Load()
    {
        if (SaveFound())
        {
            string saveString = File.ReadAllText(Path.Combine(SAVE_FOLDER, "save.json"));
            return saveString;
        }
        else
        {
            return null;
        }
    }
}
