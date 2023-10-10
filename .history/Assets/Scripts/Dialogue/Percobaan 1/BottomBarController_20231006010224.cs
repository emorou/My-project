using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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

    public GameObject CelticPrefab;
    public GameObject npcPrefab;

    void Awake()
    {
        public GameObject CelticPrefab;
     public GameObject npcPrefab;
    }
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
        Color tmp = Thugger.GetComponent<SpriteRenderer>().color;
        tmp.a = 0.5f;
        Thugger.GetComponent<SpriteRenderer>().color = tmp;
        StartCoroutine(TypeText(currentScene.sentences[++sentenceIndex].text));
        personNameText.text = currentScene.sentences[sentenceIndex].speaker.speakerName;
        Color textColor = currentScene.sentences[sentenceIndex].speaker.textColor;
        textColor.a = 1f; // Set the alpha component to 1 (opaque)
        personNameText.color = textColor;

        if(sentenceIndex % 2 != 0)
        {
            // Instantiate(speaker.characterPrefab, npcPosition.transform.position, Quaternion.identity);
            CelticPrefab.color = 
        }
        else
        {
            // Instantiate(speaker.characterPrefab, celticPosition.transform.position, Quaternion.identity);
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
