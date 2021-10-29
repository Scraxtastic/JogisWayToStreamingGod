using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class FileManager : MonoBehaviour
{
    public static string RelativeFilePath = "/save.dat";
    public static void SaveFile(SaveObject saveObject)
    {
        string destination = Application.persistentDataPath + RelativeFilePath;
        FileStream file;

        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, saveObject);
        file.Close();
    }

    public static SaveObject LoadFile()
    {
        string destination = Application.persistentDataPath + RelativeFilePath;
        FileStream file;

        if (File.Exists(destination))
        {
            file = File.OpenRead(destination);
        }
        else
        {
            Debug.LogError("File not found");
            return null;
        }

        BinaryFormatter bf = new BinaryFormatter();
        SaveObject saveObject = (SaveObject)bf.Deserialize(file);
        file.Close();
        return saveObject;

    }

}