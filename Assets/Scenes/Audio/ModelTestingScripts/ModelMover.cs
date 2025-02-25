using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelMover : MonoBehaviour
{
    public Vector3 startPosition = new Vector3(-200, 0, 0); // Start position
    public Vector3 targetPosition = new Vector3(3, -69, -35); // New target position
    public float duration = 9f; // Time to reach target
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

            // Lerp toward the new target position
            Vector3 newPosition = Vector3.Lerp(startPosition, targetPosition, t);

            // Add Sine motion to the Y-axis
            newPosition.y += Mathf.Sin(elapsedTime * waveFrequency) * waveAmplitude;

            // Apply the new position
            transform.position = newPosition;
        }
    }
}

