using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteSwitcher : MonoBehaviour
{
    public bool isSwitched = false;
    public Image image1;
    public Image image2;

    private void  Awake()
    {
        animator = GetComponent<Animator>();
    }
}
