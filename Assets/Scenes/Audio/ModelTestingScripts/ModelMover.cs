using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelMover : MonoBehaviour
{
    public Vector3 startPosition = new Vector3(-10, 0, 0); // Start position
    public float duration = 9f; // Time to reach (0,0,0)
    public float waveAmplitude = 2f; // Height of the wave
    public float waveFrequency = 2f; // Speed of the wave

    private float elapsedTime = 0f;

    void Start()
    {
        transform.position = startPosition; // Start offscreen
    }

    void Update()
    {
        if (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration); // Normalize progress

            // Lerp toward (0,0,0)
            Vector3 targetPosition = Vector3.Lerp(startPosition, Vector3.zero, t);

            // Add Sinusoidal motion to the Y-axis
            targetPosition.y += Mathf.Sin(elapsedTime * waveFrequency) * waveAmplitude;

            // Apply the new position
            transform.position = targetPosition;
        }
    }
}

