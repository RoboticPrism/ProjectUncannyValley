using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestTracker : MonoBehaviour {

    public string startText;

    Text text;
    GameObject panel;

    Coroutine textCoroutine;
    
    float currentTextSpeed = .05f;

    AudioSource audioSource;

    TextDisplay textDisplay;

    public AudioClip typeClickA;
    public AudioClip typeClickB;
    public AudioClip typeSpace;
    public AudioClip typeReturn;

    // Use this for initialization
    void Start()
    {
        panel = this.transform.GetChild(0).gameObject;
        text = panel.GetComponentsInChildren<Text>()[1];
        audioSource = GetComponent<AudioSource>();
        text.text = "";
        textDisplay = FindObjectOfType<TextDisplay>();
        if (startText != "")
        {
            AddQuest(startText);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Opens the text box and starts typing the message
    public void AddQuest(string message)
    {
        if (text)
        {
            if (textCoroutine != null)
            {
                StopText();
            }
            text.text += "\n";
            
            textCoroutine = StartCoroutine("TypeLetters", message);
        }
    }

    public void ClearQuests()
    {
        if (text)
        {
            text.text = "";
            CloseTextWindow();
        }
    }

    // Cuts the current text short and closes the text box
    void StopText()
    {
        if (text)
        {
            CloseTextWindow();
            if (textCoroutine != null)
            {
                StopCoroutine(textCoroutine);
            }
            text.text = "";
        }
    }

    // Opens the text window
    void OpenTextWindow()
    {
        panel.SetActive(true);
    }

    // Puts away and hides the text window
    void CloseTextWindow()
    {
        panel.SetActive(false);
    }
    
    // Type message coroutine
    IEnumerator TypeLetters(string message)
    {
        while (textDisplay.isOpen)
        {
            yield return null;
        }
        OpenTextWindow();
        for (int i = 0; i < message.Length; i++)
        {
            TypeNextLetter(message[i]);
            yield return new WaitForSeconds(Random.Range(currentTextSpeed, currentTextSpeed * 3));
        }
        audioSource.PlayOneShot(typeReturn);
    }

    // Types a single letter of the message
    void TypeNextLetter(char letter)
    {
        // Typewriter click noise here
        text.text += letter;
        if (letter == ' ')
        {
            audioSource.PlayOneShot(typeSpace);
        }
        else
        {
            audioSource.PlayOneShot(typeClickA);
        }
    }
}