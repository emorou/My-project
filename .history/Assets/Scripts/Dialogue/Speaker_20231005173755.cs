using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSpeaker", menuName = "Data/New Speaker")]
[System.Serializable]

public class Speaker : ScriptableObject
{
    public string speakerName;
    public Color textColor;
    public SpriteRenderer characterPrefab;
    public Sprite characterSprite;
    
}
