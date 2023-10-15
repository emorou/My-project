using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using UnityEditor;

public class ConfirmationPopupMenu : Menu
{
    [Header("Components")]
    [SerializeField] private TMP_Text displayText;
    [SerializeField] private Button confirmButton;
    [SerializeField] private Button cancelButton;
}
