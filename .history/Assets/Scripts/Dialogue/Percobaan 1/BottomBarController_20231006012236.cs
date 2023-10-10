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
    public Transform celticPosition;
    public Transform npcPosition;

    // public GameObject CelticPrefab;
    // public GameObject npcPrefab;

    private enum State
    {
        PLAYING, COMPLETED
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

        if(sentenceIndex % 2 != 0)
        {
            // Instantiate(speaker.characterPrefab, npcPosition.transform.position, Quaternion.identity);
            Image imageComponent = CelticPrefab.GetComponent<Image>();
            Color tmp = imageComponent.color;
            tmp.a = 0.5f;
            imageComponent.color = tmp;

            Image npcComponent = npcPrefab.GetComponent<Image>();
            Color tmp1 = npcComponent.color;
            tmp1.a = 1.0f;
            npcComponent.color = tmp1;
        }
        else
        {
            // Instantiate(speaker.characterPrefab, celticPosition.transform.position, Quaternion.identity);
            Image npcComponent = npcPrefab.GetComponent<Image>();
            Color tmp = npcComponent.color;
            tmp.a = 0.5f;
            npcComponent.color = tmp;

            Image imageComponent = CelticPrefab.GetComponent<Image>();
            Color tmp1 = imageComponent.color;
            tmp1.a = 1.0f;
            imageComponent.color = tmp1;
        }
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
