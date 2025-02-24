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

        Renderer backdropRenderer = backdrop.GetComponent<Renderer>();
        Color backdropColor = Color.HSVToRGB(.3f, 1f, 7f * AudioSpectrum.audioAmp);
        backdropRenderer.material.color = backdropColor;

        Debug.Log("AudioSpectrum.audioAmp: " + AudioSpectrum.audioAmp);
    }
}