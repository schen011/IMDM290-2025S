// UMD IMDM290 
// Instructor: Myungin Lee
// Flashing backdrop based on audio amplitude

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    GameObject backdrop;
    float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        backdrop = GameObject.CreatePrimitive(PrimitiveType.Cube);
        backdrop.transform.localScale += new Vector3(500, 500, 1);
        
        Renderer backdropRenderer = backdrop.GetComponent<Renderer>();
        Color backdropColor = Color.HSVToRGB(0f, 0f, 0f);
        backdropRenderer.material.color = backdropColor;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        float hue = .3f;

        if (time > 59.3f && time < 89f){
            hue = .6f + (0.06f*Mathf.Sin(AudioSpectrum.audioAmp)); // billie part
        } else if (time > 16f && time < 16.4f){
            hue = .9f;
        } else {
            hue = .31f;
        }

        Renderer backdropRenderer = backdrop.GetComponent<Renderer>();
        Color backdropColor = Color.HSVToRGB(hue, 1f, 4f * AudioSpectrum.audioAmp);
        backdropRenderer.material.color = backdropColor;

        Debug.Log("AudioSpectrum.audioAmp: " + AudioSpectrum.audioAmp);
        Debug.Log("Sec:" + time);
    }
}