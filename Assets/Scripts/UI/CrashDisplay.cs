using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrashDisplay : MonoBehaviour {

    Text text;
    GameObject panel;

    Coroutine textCoroutine;

    bool interactPressed = false;
    bool canInteract = false;

    float currentTextSpeed = .05f;

    AudioSource audioSource;

    public AudioClip typeClickA;
    public AudioClip typeClickB;
    public AudioClip typeSpace;
    public AudioClip typeReturn;

    // Use this for initialization
    void Start()
    {
        panel = this.transform.GetChild(0).gameObject;
        text = panel.GetComponentInChildren<Text>();
        audioSource = GetComponent<AudioSource>();
        text.text = "";
        StartText("Graphics Driver Failed...\nSimulation Controller Failed...\nAI Unit Controller Failed...\n\nAttemping Automated Reboot...\nAutomated Reboot Failed\n\nWorld Processing at maximum capacity\n\nPress any button to end task...");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Interact") == 1)
        {
            // On button down
            if (!interactPressed && canInteract)
            {
                Application.Quit();    
            }
            interactPressed = true;
        }
        else
        {
            interactPressed = false;
        }
    }

    // Opens the text box and starts typing the message
    public void StartText(string message)
    {
        if (text)
        {
            if (textCoroutine == null)
            {
                text.text = "";
                textCoroutine = StartCoroutine("TypeLetters", message);
            }
        }
    }


    // Type message coroutine
    IEnumerator TypeLetters(string message)
    {
        for (int i = 0; i < message.Length; i++)
        {
            TypeNextLetter(message[i]);
            yield return new WaitForSeconds(Random.Range(currentTextSpeed, currentTextSpeed * 3));
        }
        audioSource.PlayOneShot(typeReturn);
        textCoroutine = null;
        canInteract = true;
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
