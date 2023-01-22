using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

// Credits to Brackeys' Save/Load System from Youtube

public static class SaveAndLoadSystem
{
    public static int saveSlot = 0;

    public static void SaveGameData(CurrentGameState gameState)
    {
        BinaryFormatter formatter = new();
        string path = Application.persistentDataPath + "/sgd" + saveSlot;
        FileStream stream = new(path, FileMode.Create);

        StoredSessionData data = new(gameState);

        formatter.Serialize(stream, data);
        stream.Close();

        Debug.Log("Game is succesfully saved at " + path);
    }

    public static StoredSessionData LoadGameData(int slot)
    {
        string path = Application.persistentDataPath + "/sgd" + slot;

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new();
            FileStream stream = new(path, FileMode.Open);
            StoredSessionData data = formatter.Deserialize(stream) as StoredSessionData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Save file " + slot + " not found...");
            return null;
        }
    }
}