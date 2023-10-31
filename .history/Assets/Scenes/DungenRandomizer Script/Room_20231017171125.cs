using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public int Width;

    public int Height;

    public int X;

    public int Y;

    // Start is called before the first frame update
    void Start()
    {
        if(RoomController.instance == null)
        {
            return;
        }
    }

    // Update is called once per frame
   public Vector3 GetRoomCentre()
   {
        return new Vector3
   }

}
