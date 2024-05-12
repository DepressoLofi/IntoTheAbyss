using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveSystem 
{
    private static readonly string saveFolder = Application.persistentDataPath + "/PuppySaves/";
    public static void SaveData(GameManager gameManager, int slot)
    {
        string path = GetSavePath(slot);
        string data = JsonUtility.ToJson(new PlayerData(gameManager));

        if (!Directory.Exists(saveFolder))
        {
            Directory.CreateDirectory(saveFolder);
        }

        File.WriteAllText(path, data);

    }

    public static PlayerData LoadData(int slot)
    {
        string path = GetSavePath(slot);
        if(File.Exists(path))
        {
            string data = File.ReadAllText(path);
            return JsonUtility.FromJson<PlayerData>(data);
        } 
        else
        {
            Debug.LogWarning("No data found for slot" + slot);
            return null;
        }
    }

    public static void ClearData(int slot)
    {
        string path = GetSavePath(slot);
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        else
        {
            Debug.LogWarning("No data found for slot " + slot);
        }
    }

    public static bool DoesSaveExist(int slot)
    {
        string path = GetSavePath(slot);
        return File.Exists(path);
    }

    private static string GetSavePath(int slot)
    {
        return saveFolder + "PuppySlot" + slot + ".json";
    }
}
