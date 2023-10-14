using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class JsonDataService : IDataServices 
{
    public bool SaveData<T>(string Relativepath, T Data, bool Encrypted)
    {
        string path = Application.persistentDataPath + Relativepath; 
            try
            {
                if(File.Exists(path))
                {
                    Debug.Log("Rewriting data");
                    File.Delete(path);
                }
                else
                {
                    Debug.Log("Writing file for the first time");
                }
                using FileStream stream = File.Create(path);
                stream.Close();
                File.WriteAllText(path, JsonConvert.SerializeObject(Data));
                return true;
            }
            catch(Exception e)
            {
                Debug.LogError($"unable to save data due to: {e.Message} {e.StackTrace}");
                return false;
            }
    }
 

    public T LoadData<T>(string RelativePath, bool Encrypted);
    
        throw new System.NotImplementedException();
    
}
