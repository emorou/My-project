using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClass : MonoBehaviour
{
    public StageSelection[] foundObjects;
    // Start is called before the first frame update
    void Start()
    {

        foundObjects = FindObjectsOfType<StageSelection>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
