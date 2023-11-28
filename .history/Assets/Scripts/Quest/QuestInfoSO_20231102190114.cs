using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestInfoSO", menuName = "ScriptableObjects/QuestInfoSO", order = 1)]

public class QuestInfoSO : ScriptableObject
{
    [field: SerializeFieldpublic string id {get; private set;}
}
