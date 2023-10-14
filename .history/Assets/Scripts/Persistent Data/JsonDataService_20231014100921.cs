using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class JsonDataService : IDataServices 
{
    public bool SaveData<T>(string Relativepath, T Data, bool Encrypted)
    {
        string path = Application.persistentDataPath + Relativepath; 

        if(File.Exists(path))
        {
            try
            {
                Debug.Log("Rewriting data");
                File.Delete(path);
                using FileStream stream = File.Create(path);
                stream.Close();
                File.WriteAllText(path, JsonConvert.SerializeObject(Data))
            }
            catch(Exception e)
            {
                Debug.LogError($"unable to save data due to: {e.Message} {e.StackTrace}");
                return false;
            }
        }
        else
        {

        }
    }

    T LoadData<T>(string RelativePath, bool Encrypted);

    T IDataServices.LoadData<T>(string RelativePath, bool Encrypted)
    {
        throw new System.NotImplementedException();
    }
}
