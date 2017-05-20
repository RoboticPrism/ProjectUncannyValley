using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractController : MonoBehaviour {

    public GameObject interactIcon;
    bool interactPressed = false;
    public InteractSpot currentInteract;

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
