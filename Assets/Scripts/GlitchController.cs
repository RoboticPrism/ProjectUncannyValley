using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchController : MonoBehaviour {

    Camera camera;
    Kino.AnalogGlitch ag;
    Kino.DigitalGlitch dg;

    public float analogGlitchChance = 0.5f;
    public float analogGlitchMaxIntensity = 0.2f;
    public float digitalGlitchChance = 0.5f;
    public float digitalGlitchMaxIntensity = 0.2f;

    // Use this for initialization
    void Start () {
        camera = FindObjectOfType<Camera>();
        ag = camera.GetComponent<Kino.AnalogGlitch>();
        dg = camera.GetComponent<Kino.DigitalGlitch>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Random.Range(0f, 1f) < analogGlitchChance)
        {
            ag.scanLineJitter = Random.Range(0f, analogGlitchMaxIntensity);
            ag.colorDrift = Random.Range(0f, analogGlitchMaxIntensity);
        } else
        {
            ag.scanLineJitter = 0f;
            ag.colorDrift = 0f;
        }
        if (Random.Range(0f, 1f) < digitalGlitchChance)
        {
            dg.intensity = Random.Range(0f, digitalGlitchMaxIntensity);
        } else
        {
            dg.intensity = 0f;
        }
	}

    void TriggerDigitalGlitch(float intensity)
    {
        StartCoroutine("DigitalGlitch", intensity);
    }

    void TriggerAnalogGlitch(float intensity)
    {
        StartCoroutine("AnalogGlitch", intensity);
    }

    IEnumerator DigitalGlitch(float intensity)
    {
        for (float f = 0.5f; f > 0; f -= .01f)
        {
            dg.intensity = f;
            yield return null;
        }
    }

    IEnumerator AnalogGlitch(float intensity)
    {
        for (float f = 0.5f; f > 0; f -= .01f)
        {
            ag.scanLineJitter = f;
            ag.colorDrift = f;
            yield return null;
        }
    }
}
