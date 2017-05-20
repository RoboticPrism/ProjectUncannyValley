using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextInteractSpot : InteractSpot {
    public TextDisplay textDisplay;
    public string message;

	// Use this for initialization
	void Start () {
        textDisplay = FindObjectOfType<TextDisplay>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Displays text on interact
    new public void Interact()
    {
        textDisplay.StartText(message);
    }
}
