using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public TMP_Text tutorialText;
    public GameObject panel;

    void Update()
    {
        if(panel.activeSelf && Input.GetMouseButtonDown(0))
        {
            panel.SetActive(false);
        }

        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            tutorialText.text =     
        }
    }
}
