using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefridgeratorAnim : MonoBehaviour {

    TextDisplay textDisplay;
    public bool open = false;
    Coroutine coroutine;
    public float openSpeed = 0.7f;
    public float maxOpenDegrees = 45f;

    // Use this for initialization
    void Start () {
        textDisplay = FindObjectOfType<TextDisplay>();
    }
	
	// Update is called once per frame
	void Update () {
		if (open && !textDisplay.isOpen)
        {
            CloseFridge();
        }
	}

    public void OpenFridge()
    {
        if (!open)
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }
            open = true;
            coroutine = StartCoroutine("OpenAnim");
        }
    }

    public void CloseFridge()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        open = false;
        coroutine = StartCoroutine("CloseAnim");
    }

    IEnumerator OpenAnim()
    {
        for (float i = 0; i < maxOpenDegrees; i += openSpeed)
        {
            transform.localEulerAngles = new Vector3(0f, i, 0f);
            yield return null;
        }
    }

    IEnumerator CloseAnim()
    {
        for (float i = transform.localEulerAngles.y ; i > 0; i-= openSpeed)
        {
            
            transform.localEulerAngles = new Vector3(0f, i, 0f);
            yield return null;
        }
    }
}
