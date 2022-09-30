using UnityEngine;
using System.IO;

public static class SaveManager
{
    public static string directory = "/SaveData/";
    public static string fileName = "Score.txt";
    // Start is called before the first frame update
    public static void Save(SaveObject savedObject)
    {
        string dir = Application.persistentDataPath + directory;

        if(!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string json = JsonUtility.ToJson(savedObject);
        File.WriteAllText(dir + fileName, json);
    }

    public static SaveObject Load()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        SaveObject savedObject = new SaveObject();

        if(File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            savedObject = JsonUtility.FromJson<SaveObject>(json);
            Debug.Log(savedObject);
        }
        else
        {
            Debug.Log("There's no save!");
        }

        return savedObject;
    }
}
