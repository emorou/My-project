using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkExternalFunctions
{
    public void Bind(Story story)
    {
        story.BindExternalFunction("BackToIntro", BackToIntro);
        story.BindExternalFunction("StartTutorial", StartTutorial);
    }

    public void Unbind(Story story)
    {

    }

     public void BackToIntro()
    {
        SceneManager.LoadSceneAsync("Intro");
    }

    public void StartTutorial()
    {
        Tutorial.instance.tutorialSlide.SetActive(true);
    }
}
