using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using System.IO;

public class DialogueVariables : MonoBehaviour
{
    private Dictionary<string, Ink.Runtime.Object> variables;

    public DialogueVariables(string globalFilePath)
    {
        string inkFileContents = File.ReadAllText(globalFilePath)
    }
    public void StartListening(Story story)
    {
        story.variablesState.variableChangedEvent += VariableChanged;
    }

    public void StopListening(Story story)
    {
        story.variablesState.variableChangedEvent -= VariableChanged;
    }

    private void VariableChanged(string name, Ink.Runtime.Object value)
    {
        Debug.Log("Variable changed: " + name + " = " + value);
    }
}
