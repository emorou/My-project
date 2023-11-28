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
        story.BindExternalFunction("SafeZoneTutorialDone", SafeZoneTutorialDone);
        story.BindExternalFunction("Chamber1TutorialDone", Chamber1TutorialDone);
        // story.BindExternalFunction("PlayEmote", (string emoteName) => PlayEmote(EmoteName, emoteAnimator));
    }

    public void Unbind(Story story)
    {
        story.UnbindExternalFunction("BackToIntro");
        story.UnbindExternalFunction("StartTutorial");
        story.UnbindExternalFunction("SafeZoneTutorialDone");
    }

     public void BackToIntro()
    {
        SceneManager.LoadSceneAsync("Intro");
    }

    public void StartTutorial()
    {
        DialogueManager.instance.dialogueIsPlaying = false;
        DialogueManager.instance.dialoguePanel.SetActive(false);
        Tutorial.instance.tutorialSlide1.SetActive(true);
    }

    /* public void PlayEmote(string emoteName, Animator emoteAnimator)
    {
        asokdaoskdoa
    }
    */

    public void SafeZoneTutorialDone()
    {
        DialogueManager.instance.dialogueIsPlaying = false;
        DialogueManager.instance.dialoguePanel.SetActive(false);
        Tutorial.instance.isSafeZoneTutorialDone = true;
    }

    public void Chamber1TutorialDone()
    {
        DialogueManager.instance.dialogueIsPlaying = false;
        DialogueManager.instance.dialoguePanel.SetActive(false);
        Tutorial.instance.isChamber1TutorialDone = true;
    }
}
