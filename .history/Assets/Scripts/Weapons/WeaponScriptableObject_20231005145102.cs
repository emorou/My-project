using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "ScriptableObjects/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    [SerializeField]
    GameObject prefab;
    public GameObject Prefab {get => prefab; private set => prefab = value;}

    [SerializeField]
    float damage;
    public float Damage {get => damage; private set => damage = value;} 

    [SerializeField]
    float speed;
    public float Speed {get => speed; private set => speed = value;} 

    [SerializeField]
    float cooldownDurationranged;
    public float CooldownDurationranged {get => cooldownDurationmelee; private set => cooldownDurationmelee = value;} 

    [SerializeField]
    float cooldownDurationmelee;
    public float CooldownDurationMelee {get => cooldownDurationmelee; private set => cooldownDurationmelee = value;} 
}
