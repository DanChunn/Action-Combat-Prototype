
using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour
{

    public LayerMask targetMask;

    void Start()
    {
        transform.rotation = Camera.main.transform.localRotation;
        //originalDotColour = dot.color;
    }

    void Update()
    {
        //transform.Rotate(Vector3.forward * -40 * Time.deltaTime);
    }

    public void DetectTargets(Ray ray)
    {
        if (Physics.Raycast(ray, 100, targetMask))
        {
            
        }
        else
        {
            
        }
    }
}