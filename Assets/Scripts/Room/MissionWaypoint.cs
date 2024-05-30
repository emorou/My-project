using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionWaypoint : MonoBehaviour
{
    // Indicator icon
    public Image img;
    // The target (location, enemy, etc..)
    public List<Transform> target;
    public int targetNumber;
    // UI Text to display the distance
    public TMP_Text meter;
    // To adjust the position of the icon
    public Vector3 offset;

    public GameObject waypoint;
    public bool canWaypoint;
    public static MissionWaypoint instance;

    void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if(DialogueManager.instance.dialogueIsPlaying || Vector3.Distance(target[targetNumber].position, transform.position) <= 15)
        canWaypoint = false;
        else
        canWaypoint = true;

        ActivateWaypoint();
    }

    public void WaypointMarking()
    {
        // Giving limits to the icon so it sticks on the screen
        // Below calculations witht the assumption that the icon anchor point is in the middle
        // Minimum X position: half of the icon width
        float minX = img.GetPixelAdjustedRect().width / 2;
        // Maximum X position: screen width - half of the icon width
        float maxX = Screen.width - minX;

        // Minimum Y position: half of the height
        float minY = img.GetPixelAdjustedRect().height / 2;
        // Maximum Y position: screen height - half of the icon height
        float maxY = Screen.height - minY;

        // Temporary variable to store the converted position from 3D world point to 2D screen point
        Vector2 pos = Camera.main.WorldToScreenPoint(target[targetNumber].position + offset);

        // Check if the target is behind us, to only show the icon once the target is in front
        if(Vector3.Dot((target[targetNumber].position - transform.position), transform.forward) < 0)
        {
            // Check if the target is on the left side of the screen
            if(pos.x < Screen.width / 2)
            {
                // Place it on the right (Since it's behind the player, it's the opposite)
                pos.x = maxX;
            }
            else
            {
                // Place it on the left side
                pos.x = minX;
            }
        }

        // Limit the X and Y positions
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        // Update the marker's position
        img.transform.position = pos;
        // Change the meter text to the distance with the meter unit 'm'
        meter.text = ((int)Vector3.Distance(target[targetNumber].position, transform.position)).ToString() + "m";
    }

    public void ActivateWaypoint()
    {
        if(canWaypoint)
        {
        waypoint.SetActive(true);
        WaypointMarking();
        }
        else
        waypoint.SetActive(false);
    }
}