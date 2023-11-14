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
        tutorialText.text = "";
        if(panel.activeSelf && Input.GetMouseButtonDown(0) && !DialogueManager.instance.dialogueIsPlaying)
        {
            tutorialText.text = "";
            panel.SetActive(false);
        }

        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            panel.SetActive(true);
            tutorialText.text = "Pencet Klik kiri dan klik kanan";
        }
    }
}
