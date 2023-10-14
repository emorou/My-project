using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class JsonDataService : IDataServices 
{
    public bool saveData<T>(string Relativepath, T data, bool Encrypted)
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
        }
        else
        {

        }
    }

    T LoadData<T>(string RelativePath, bool Encrypted);   
}
