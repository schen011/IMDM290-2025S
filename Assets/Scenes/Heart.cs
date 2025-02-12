// Modified from Animate.cs 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    GameObject[] shapes;
    static int numShape = 5000;   
    float time = 0f;
    Vector3[] initPos;
    // Start is called before the first frame update
    void Start()
    {
        shapes = new GameObject[numShape];
        initPos = new Vector3[numShape];

        // Let there be shapes..
        for (int i =0; i < numShape; i++){
            float r = 6f; // scalar of heart
            // Draw primitive elements:
            // https://docs.unity3d.com/6000.0/Documentation/ScriptReference/GameObject.CreatePrimitive.html
            shapes[i] = GameObject.CreatePrimitive(PrimitiveType.Cylinder); 
            // Initial positions of the spheres. make it in circle with r radius.
            // https://www.cuemath.com/geometry/unit-circle/
            initPos[i] = new Vector3(r * Mathf.Sqrt(2f) * Mathf.Sin(i) *  Mathf.Sin(i) *  Mathf.Sin(i), 
                                     r * (- Mathf.Cos(i) * Mathf.Cos(i) * Mathf.Cos(i) - Mathf.Cos(i) * Mathf.Cos(i) + 2 *Mathf.Cos(i)) + 3f, 10f);

            shapes[i].transform.position = initPos[i];

            shapes[i].transform.rotation = Random.rotation; // randomize shape rotation

            // Get the renderer of the spheres and assign colors.
            Renderer sphereRenderer = shapes[i].GetComponent<Renderer>();
            // hsv color space: https://en.wikipedia.org/wiki/HSL_and_HSV
            float hue = (float)i / numShape; // Hue cycles through 0 to 1
            Color color = Color.HSVToRGB(hue, 1f, 1f); // Full saturation and brightness
            sphereRenderer.material.color = color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        // what to update?
        for (int i =0; i < numShape; i++){
            // position
            shapes[i].transform.position = initPos[i] 
                                            + new Vector3(Mathf.Sin(time) * 1f, 
                                            Mathf.Cos(time/2f)* 2f, Mathf.Cos(4f*time) * 
                                            2f + Mathf.Sin(time)*i/100);    // adjusts z position over time, unique to each shape
            // color
            Renderer sphereRenderer = shapes[i].GetComponent<Renderer>();
            float hue = (float)i / numShape; 
            Color color = Color.HSVToRGB(Mathf.Abs(hue * Mathf.Sin(time*3)), Mathf.Cos(time), // cycling hue, full saturation
                                                        3f + i/300 * Mathf.Cos(time/1.5f -1f)); // cycling brightness
            sphereRenderer.material.color = color;
            shapes[i].transform.rotation = Random.rotation; //rotate shapes
        }
    }
}
