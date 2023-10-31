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

    public void ActivateMenu(string displayText, UnityAction confirmAction, UnityAction cancelAction)
    {
        this.gameObject.SetActive(true);

        this.displayText.text = displayText;

        confirmButton.onClick.RemoveAllListeners();
        cancelButton.onClick.RemoveAllListeners();

        confirmButton.onClick.AddListener(() => {
            DeactivateMenu();
            confirmAction();
        });

        cancelButton.onClick.AddListener(() => {
            DeactivateMenu();
            cancelAction();
        });
    }

    private void DeactivateMenu()
    {
        this.gameObject.setActive(false);
    }
}
