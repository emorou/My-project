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
        story.BindExternalFunction("BossRoomTutorial",BossRoomTutorial);
        story.BindExternalFunction("TutorialDone", TutorialDone);
        // story.BindExternalFunction("PlayEmote", (string emoteName) => PlayEmote(EmoteName, emoteAnimator));
    }

    public void Unbind(Story story)
    {
        story.UnbindExternalFunction("BackToIntro");
        story.UnbindExternalFunction("StartTutorial");
        story.UnbindExternalFunction("SafeZoneTutorialDone");
        story.UnbindExternalFunction("Chamber1TutorialDone");
        story.UnbindExternalFunction("BossRoomTutorial");
        story.UnbindExternalFunction("TutorialDone");
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
        Tutorial.instance.warpGate3.SetActive(false);
    }

    public void Chamber1TutorialDone()
    {
        DialogueManager.instance.dialogueIsPlaying = false;
        DialogueManager.instance.dialoguePanel.SetActive(false);
        Tutorial.instance.isChamber1TutorialDone = true;
        Tutorial.instance.warpGate5.SetActive(false);
    }

    public void BossRoomTutorial()
    {
        DialogueManager.instance.dialogueIsPlaying = false;
        DialogueManager.instance.dialoguePanel.SetActive(false);
        Tutorial.instance.isEnterBossRoom = true;
    }

    public void TutorialDone()
    {
        Tutorial.instance.tutorialDone.SetActive(true);
    }

    public void EasterEggMusicPlay()
    {
        Tutorial.instance.musikBagas.Play();
        Tutorial.instance.musikTutorial.Stop();
    }

     public void EasterEgg()
    {
        DialogueManager.instance.dialogueIsPlaying = false;
        DialogueManager.instance.dialoguePanel.SetActive(false);
        Tutorial.instance.enterEasterEgg = true;
    }
}
