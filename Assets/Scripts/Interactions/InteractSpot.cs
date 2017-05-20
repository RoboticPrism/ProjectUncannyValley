using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractSpot : MonoBehaviour {

    public UnityEvent afterInteractActions;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
        
    // The interact event for this
    public void Interact()
    {
        afterInteractActions.Invoke();
    }
}
