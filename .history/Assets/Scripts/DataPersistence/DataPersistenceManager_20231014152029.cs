using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    public static DataPersistenceManager instance {get; private set;}

    private void  Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Found more than one daata persistence manager in this scene");
        }
        instance = this;
    }
}
