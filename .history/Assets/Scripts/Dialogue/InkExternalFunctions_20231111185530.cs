using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.SceneManagement;

public class InkExternalFunctions
{
    public void Bind(Story story)
    {
        story.BindExternalFunction("BackToIntro", BackToIntro);
        story.BindExternalFunction("StartTutorial", StartTutorial);

        // story.BindExternalFunction("PlayEmote", (string emoteName) => PlayEmote(EmoteName, emoteAnimator));
    }

    public void Unbind(Story story)
    {
        story.UnbindExternalFunction("BackToIntro");
        story.UnbindExternalFunction("StartTutorial");
    }

     public void BackToIntro()
    {
        SceneManager.LoadSceneAsync("Intro");
    }

    public void StartTutorial()
    {
        DialogueManager.instance.dialo
        Tutorial.instance.tutorialSlide.SetActive(true);
    }

    /* public void PlayEmote(string emoteName, Animator emoteAnimator)
    {
        asokdaoskdoa
    }
    */
}
