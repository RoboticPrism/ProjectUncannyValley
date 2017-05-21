using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteGlitcher : MonoBehaviour {

    AudioSource audioSource;

    public AudioClip glitchNoise;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Round(Time.time) % 10 == 0)
        {
            if (Random.Range(0f, 1f) > 0.9f)
            {
                transform.localScale = new Vector3(transform.localScale.x, -1f, transform.localScale.z);
                audioSource.PlayOneShot(glitchNoise);
            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x, 1f, transform.localScale.z);
            }
        }
	}
}
