using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonDataService : IDataServices 
{
    public bool saveData<T>(string Relativepath, T data, bool Encrypted)
    {
        string path = Application.persistentDataPath + Relativepath; 

        if(File.Exists(path))
        {
            
        }
        else
        {

        }
    }

    T LoadData<T>(string RelativePath, bool Encrypted);   
}
