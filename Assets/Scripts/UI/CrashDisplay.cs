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

    float currentTextSpeed = .07f;

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
		StartText("> Graphics Driver... Failed\n> Simulation Controller... Failed\n> AI Unit Controller... Failed\n>\n> Attempting Automated Reboot...\n> _____\n> Automated Reboot Failed\n> \n> World Processing at maximum capacity\n>\n>\n>\n> Created as a part of the Gr8 Art Games Jam - Boston\n>\n> David Song ................ 3D Art\n> Michelle Houle ............ Sound and Interaction Design\n> Ryan Stewart .............. Programming and Project Manager\n> Victoria Barranco ......... 2D Art\n>\n>\n>\n>Press any button to end task...");
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
