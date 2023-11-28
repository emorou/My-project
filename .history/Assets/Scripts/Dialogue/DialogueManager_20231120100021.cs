using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [Header("Parameter")]
    [SerializeField] private float typingSpeed = 0.04f;

    [Header("Dialogue UI")]
    [SerializeField] public GameObject dialoguePanel;
    [SerializeField] private GameObject continueIcon;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private TMP_Text displayNameText;
    [SerializeField] private Animator rightAnimator;
    [SerializeField] private Animator leftAnimator;
    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;

    [SerializeField] private TextAsset inkJSON;
    
    private TMP_Text[] choicesText;

    private Story currentStory;

    public bool dialogueIsPlaying;

    public static DialogueManager instance {get; private set;}

    private const string SPEAKER_TAG = "speaker";
    private const string RIGHTSPRITE_TAG = "right sprite";
    private const string LEFTSPRITE_TAG = "left sprite";

    private bool canContinueToNextLine = false;
    private Coroutine displayLineCoroutine;

    private InkExternalFunctions inkExternalFunctions;
    private void Awake()
    {
        inkExternalFunctions = new InkExternalFunctions();
        instance = this;
    }

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if(sceneName == "Level Tutorial")
        {
            EnterDialogueMode(inkJSON);
            dialogueIsPlaying = true;
            dialoguePanel.SetActive(true);
        }
        else
        {
            dialogueIsPlaying = false;
            dialoguePanel.SetActive(false); 
        }

        choicesText = new TMP_Text[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TMP_Text>();
            index++;
        }
    }

    private void Update()
    {
        if(!dialogueIsPlaying)
        {
            return;
        }

        if(canContinueToNextLine && currentStory.currentChoices.Count == 0 && Input.GetKeyDown(KeyCode.E) | Input.GetMouseButtonDown(0))
        {
            ContinueStory();    
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        inkExternalFunctions.Bind(currentStory);
      
        displayNameText.text = "???";
        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        inkExternalFunctions.Unbind(currentStory);
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if(currentStory.canContinue)
        {
            if(displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }
            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
            HandleTags(currentStory.currentTags);
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private IEnumerator DisplayLine(string line)
    {
        dialogueText.text = line;
        dialogueText.maxVisibleCharacters = 0;
        continueIcon.SetActive(false);
        canContinueToNextLine = false;
        HideChoices();
        
        bool isAddingRichTextTag = false;

        foreach (char letter in line.ToCharArray())
        {
            
            if(Input.GetKeyDown(KeyCode.E))
            if(letter == '<' || isAddingRichTextTag)
            {
                isAddingRichTextTag = true;
                dialogueText.text += letter;
                if(letter == '>')
                {
                    isAddingRichTextTag = false;
                }
            }
            else
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }

        continueIcon.SetActive(true );
        DisplayChoices();
        canContinueToNextLine = true;
    }

    private void HideChoices()
    {
        foreach (GameObject choicebutton in choices)
        {
            choicebutton.SetActive(false);
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if(splitTag.Length != 2)
            {
                Debug.LogError("Slah tag");
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case SPEAKER_TAG:
                displayNameText.text = tagValue;
                break;
                case RIGHTSPRITE_TAG:
                rightAnimator.Play(tagValue);
                break;
                case LEFTSPRITE_TAG:
                leftAnimator.Play(tagValue);
                break;
                default:
                Debug.LogWarning("Tag came in but is not currently being handled: " + tag);
                break;
            }
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if(currentChoices.Count > choices.Length)
        {
            Debug.LogError("Kelebihan choicesnya bg");
        }

        int index = 0;

        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        if(canContinueToNextLine)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
            ContinueStory();
        }
    }
}
