using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageManager : MonoBehaviour
{
    public TMP_Text goldText;
    public TMP_Text levelText;
    public TMP_Text healthText;
    public TMP_Text bulletText;

   void Start()
    {
        level = FindObjectOfType<PlayerLevel>();
        knifeController = FindObjectOfType<KnifeController>();
    }
}
