using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BottomBarController : MonoBehaviour
{
    public TMP_Text barText;
    public TMP_Text personNameText;

    private int sentenceIndex = -1;
    private StoryScene currentScene;
    private Speaker speaker;
    private State state = State.COMPLETED;
    private Animator animator;
    private bool isHidden = false; 
    public Transform celticPosition;
    public Transform npcPosition;

    
    private enum State
    {
        PLAYING, COMPLETED
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Hide()
    {
        if(!isHidden)
        {
            animator.SetTrigger("Hide");
            isHidden = true;
        }
    }

    public void Show()
    {
        animator.SetTrigger("Show");
        isHidden = false;
    }

    public void PlayScene(StoryScene scene)
    {
        currentScene = scene;
        sentenceIndex = -1;
        PlayNextSentence();
    }

    public void PlayNextSentence()
    {
        StartCoroutine(TypeText(currentScene.sentences[++sentenceIndex].text));
        personNameText.text = currentScene.sentences[sentenceIndex].speaker.speakerName;
        Color textColor = currentScene.sentences[sentenceIndex].speaker.textColor;
        textColor.a = 1f; // Set the alpha component to 1 (opaque)
        personNameText.color = textColor;

        if (speaker.characterPrefab != null && celticPosition != null)
{
    Instantiate(speaker.characterPrefab, celticPosition.transform.position, Quaternion.identity);
}
else
{
    Debug.LogError("speaker.characterPrefab or celticPosition is not assigned.");
}
        // if(sentenceIndex % 2 != 0)
        // {
        //     Instantiate(speaker.characterPrefab, npcPosition.transform.position, Quaternion.identity);
        // }
        // else
        // {
        //     Instantiate(speaker.characterPrefab, celticPosition.transform.position, Quaternion.identity);
        // }
    }

    public bool IsCompleted()
    {
        return state == State.COMPLETED;
    }

    public void StartOver()
    {
        sentenceIndex = -1;
    }
    public bool IsLastSentence()
    {
        return sentenceIndex + 1 == currentScene.sentences.Count;
    }
    
    private IEnumerator TypeText(string text)
    {
        barText.text = "";
        state = State.PLAYING;
        int wordIndex = 0;

        while(state != State.COMPLETED)
        {
            barText.text += text[wordIndex];
            yield return new WaitForSeconds(0.05f);
            if(++wordIndex == text.Length)
            {
                state = State.COMPLETED;
                break;
            }
        }
    }
}
