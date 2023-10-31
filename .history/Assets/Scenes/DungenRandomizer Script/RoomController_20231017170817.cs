using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomInfo
{
    public string name;

    public int x;
    
    public int y;   
}

public class RoomController : MonoBehaviour
{
    public RoomController instance;

    string currentWorldName = "Basement";

    RoomInfo currentLoadRoomData;
    
    Queue<RoomInfo> loadRoomQueue = new Queue<RoomInfo>();

    public List<Room> loadedRooms = new List<Room>
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
