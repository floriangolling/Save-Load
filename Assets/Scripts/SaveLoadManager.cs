using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SavableData
{
    public int level;

    public SavableData(int _level)
    {
        this.level = _level;
    }
}

public static class SaveLoadManager
{
    public static void saveData(int _level)
    {
        SavableData dataChecker = loadData();
        if (dataChecker != null && dataChecker.level >= _level)
        {
            return;
        }
        string path = Application.persistentDataPath + "/data.test";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        SavableData data = new SavableData(_level);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SavableData loadData()
    {
        string path = Application.persistentDataPath + "/data.test";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SavableData data = formatter.Deserialize(stream) as SavableData;
            stream.Close();
            return data;
        } else {
            Debug.Log("No file found");
            return null;
        }
    }
}
