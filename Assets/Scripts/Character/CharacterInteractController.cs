using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractController : MonoBehaviour {

    public GameObject interactIcon;
    bool interactPressed = false;
    public TextInteractSpot currentTextInteract;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Interact") == 1)
        {
            // On button down
            if (!interactPressed)
            {
                if (currentTextInteract)
                {
                    currentTextInteract.Interact();
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
        if (other.GetComponent<TextInteractSpot>())
        {
            currentTextInteract = other.GetComponent<TextInteractSpot>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<InteractSpot>())
        {
            currentTextInteract = null;
            interactIcon.SetActive(false);
        }
    }
}
