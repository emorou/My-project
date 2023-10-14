using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonDataService : IDataServices
{
    bool saveData<T>(string Relativepath, T data, bool Encrypted);

    T LoadData<T>(string RelativePath, bool Encrypted);   
}
