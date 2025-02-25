// Unity Audio Spectrum Plot Example
// IMDM 327 Class Material 
// Author: Myungin Lee
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpectrumPlotFlat : MonoBehaviour
{
    // Scale the plot
    [Range(1f, 200f)]
    public float scale = 10;

    [Range(-300f, 300f)]
    public float posLR = 0;

    [Range(0f, 1f)]
    public float huescalar = 0;

    [Range(0f, 1f)]
    public float hueshift = 0;

    // frequency bins are intervals between samples in frequency domain
    GameObject[] sampleBin = new GameObject[AudioSpectrum.FFTSIZE];

    void Start()
    {
        // For every frequency bin
        for (int i = 0; i < sampleBin.Length; i++)
        {   // Create GO and init position
            sampleBin[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            sampleBin[i].transform.position = new Vector3(i * 0.01f - 5, 0, 0);
            //sampleBin[i].transform.Rotate(Random.Range(-180f, 180f), Random.Range(-180f, 180f), Random.Range(-180f, 180f));
        }
    }
    void Update() 
    {
        for (int i = 0; i < sampleBin.Length; i++)
        {
            if (sampleBin != null)
            {
                sampleBin[i].transform.localScale = new Vector3(0.5f, AudioSpectrum.samples[i] * scale * scale, 0.5f);
                //sampleBin[i].GetComponent<Renderer>().material.color = new Color(0.3f + (float)i / 100f, 0.1f + i / 30f, 1+ i / 500f);
                Color color = Color.HSVToRGB(Mathf.Abs((0.0f + (float)i / 1000f)) * huescalar + hueshift, 0.7f + i / 30f, 1 + i / 500f); // Full saturation and brightness
                sampleBin[i].GetComponent<Renderer>().material.color = color;

                float x = scale * Mathf.Sin((float)i / 100f) + AudioSpectrum.samples[i] * scale ;
                float y = scale * Mathf.Cos((float)i / 100f) + AudioSpectrum.samples[i] * scale * scale;

                sampleBin[i].transform.position = new Vector3(x + posLR, y, -50f);
                
                // sampleBin[i].transform.Rotate(AudioSpectrum.samples[i], 0f, Mathf.Sin(AudioSpectrum.samples[i]) * AudioSpectrum.samples[i] * scale * scale);
            }
        }

    }
}