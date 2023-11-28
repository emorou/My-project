using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkExternalFunctions
{
    public void Bind(Story story)
    {
        currentStory.BindExternalFunction("BackToIntro", BackToIntro);
        currentStory.BindExternalFunction("StartTutorial", StartTutorial);
    }

    public void Unbind(Story story)
    {

    }
}
