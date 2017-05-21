using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarpSpot : MonoBehaviour {

    public int sceneIndex;
    public TextDisplay textDisplay;
    public QuestTracker questTracker;

    // Use this for initialization
    void Start () {
        textDisplay = FindObjectOfType<TextDisplay>();
        questTracker = FindObjectOfType<QuestTracker>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //Warps the character to a new scene
    public void Warp()
    {
        if (!textDisplay.isOpen && questTracker.isOpen)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        //StopCoroutine("TryWarp");
        //StartCoroutine("TryWarp");
    }

    IEnumerator TryWarp()
    {
        while (textDisplay.isOpen || questTracker.isOpen)
        {
            yield return null;
        }
        SceneManager.LoadScene(sceneIndex);
    }
}
