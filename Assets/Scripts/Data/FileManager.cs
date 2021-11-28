using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class FileManager<T>
{
    public string RelativeFilePath { get; set; }
    public FileManager()
    {

    }

    public FileManager(string relativeFilePath)
    {
        RelativeFilePath = relativeFilePath;
    }

    public void SaveFile(T saveObject)
    {
        string destination = Application.persistentDataPath + RelativeFilePath;
        FileStream file;

        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, saveObject);
        file.Close();
    }

    public T LoadFile()
    {
        try
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
                return default;
            }

            BinaryFormatter bf = new BinaryFormatter();
            T saveObject = (T)bf.Deserialize(file);
            file.Close();
            return saveObject;
        }
        catch (UnauthorizedAccessException)
        {
            return default;
        }
    }

}
