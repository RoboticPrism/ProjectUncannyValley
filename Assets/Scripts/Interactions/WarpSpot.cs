using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarpSpot : MonoBehaviour {

    public Scene targetScene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Warps the character to a new scene
    public void Warp()
    {
        if (targetScene != null)
        {
            SceneManager.LoadScene(targetScene.name);
        }
    }
}
