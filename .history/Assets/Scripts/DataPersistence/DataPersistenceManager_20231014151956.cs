using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    public static DataPersistenceManager instance {get; private set;}

    private void void Awake()
    {
        if(instance != null)
    }
}
