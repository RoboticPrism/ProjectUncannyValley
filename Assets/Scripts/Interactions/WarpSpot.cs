using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarpSpot : MonoBehaviour {

    public int sceneIndex;
    TextDisplay textDisplay;

    // Use this for initialization
    void Start () {
        textDisplay = FindObjectOfType<TextDisplay>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //Warps the character to a new scene
    public void Warp()
    {
        StartCoroutine("TryWarp");
    }

    IEnumerator TryWarp()
    {
        while (textDisplay.isOpen)
        {
            yield return null;
        }
        SceneManager.LoadScene(sceneIndex);
    }
}
