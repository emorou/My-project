using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonDataService : IDataServices 
{
    public bool saveData<T>(string Relativepath, T data, bool Encrypted)
    {
        string path = Application.
    }

    T LoadData<T>(string RelativePath, bool Encrypted);   
}
