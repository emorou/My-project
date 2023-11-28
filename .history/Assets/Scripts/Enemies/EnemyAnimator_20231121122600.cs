using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    Animator am;
    EnemyMovement em;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        am = GetComponent<Animator>();
        em = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
