using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour {

    Text text;
    GameObject panel;

    Coroutine textCoroutine;

    bool interactPressed = false;
    public bool canInteract = false;

    float normalTextSpeed = .05f;
    float fastTextSpeed = .01f;
    float currentTextSpeed = .05f;

	// Use this for initialization
	void Start () {
        panel = this.transform.GetChild(0).gameObject;
        text = panel.GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Interact") == 1)
        {
            // On button down
            if (!interactPressed)
            {
                if (canInteract)
                {
                    CloseTextWindow();
                }
            }
            interactPressed = true;
            // speed up text while held
            currentTextSpeed = fastTextSpeed;

        } else
        {
            interactPressed = false;
            // slow down text to normal when released
            currentTextSpeed = normalTextSpeed;
        }
	}

    // Opens the text box and starts typing the message
    public void StartText(string message)
    {
        if (text)
        {
            if (textCoroutine != null)
            {
                StopText();
            }
            text.text = "";
            OpenTextWindow();
            canInteract = false;
            textCoroutine = StartCoroutine("TypeLetters", message);
        }
    }

    // Cuts the current text short and closes the text box
    void StopText()
    {
        if (text)
        {
            CloseTextWindow();
            canInteract = true;
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
        for (int i = 0; i < message.Length; i++)
        {
            TypeNextLetter(message[i]);
            yield return new WaitForSeconds(Random.Range(currentTextSpeed, currentTextSpeed * 3));
        }
        canInteract = true;
    }

    // Types a single letter of the message
    void TypeNextLetter(char letter)
    {
        // Typewriter click noise here
        text.text += letter;
    }
}
