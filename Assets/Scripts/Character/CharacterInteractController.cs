using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractController : MonoBehaviour {

    public GameObject interactIcon;
    bool interactPressed = false;
    public InteractSpot currentInteract;
    TextDisplay textDisplay;

    // Use this for initialization
    void Start () {
        textDisplay = FindObjectOfType<TextDisplay>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Interact") == 1)
        {
            // On button down
            if (!interactPressed)
            {
                if (currentInteract)
                {
                    currentInteract.Interact();
                }
            }
            interactPressed = true;
        }
        else
        {
            interactPressed = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<InteractSpot>())
        {
            interactIcon.SetActive(true);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<InteractSpot>())
        {
            currentInteract = other.GetComponent<InteractSpot>();
            if (textDisplay.isOpen)
            {
                interactIcon.SetActive(false);
            } else
            {
                interactIcon.SetActive(true);
            }
        } else
        {
            interactIcon.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<InteractSpot>())
        {
            currentInteract = null;
            interactIcon.SetActive(false);
        }
    }
}
