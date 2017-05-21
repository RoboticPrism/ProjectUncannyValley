using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject character;
    public float maxX = 0.0f;
    public float minX = 0.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(
            Mathf.Max(Mathf.Min(character.transform.position.x, maxX), minX), 
            transform.position.y, 
            transform.position.z);
	}
}
