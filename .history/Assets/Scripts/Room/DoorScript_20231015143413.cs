using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] Transform posToGo;
    [SerializeField] GameObject keyTxt;
    bool playerDetected;
    GameObject playerGO;
    // Start is called before the first frame update
    void Start()
    {
        playerDetected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerDetected)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                playerGO.transform.position = posToGo.position;
                playerDetected = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            playerDetected = true;
            playerGO = col.gameObject;
            keyTxt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        playerDetected = false;
        if(keyTxt != null)
        {
            keyTxt.SetActive(false);
        }
        keyTxt.SetActive(false);
    }
}
