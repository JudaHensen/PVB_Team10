using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ZeemijnDetectie : MonoBehaviour
{
    private InputManager _input;
    private float _range = 5f;
    public Action PlantExplosive;
    private bool detectedMine = false;

    private void Start()
    {
        _input.Interact += StartQuickTimeEvent;
    }
    void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, _range))
        {
            // Draw line in scene view to visualize raycast
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            detectedMine = true;
        }
        else
        {
            detectedMine = false;
        }
    }

    void StartQuickTimeEvent()
    {
        Debug.Log("Test");
        if (detectedMine)
        {
            Debug.Log("Good Test");
        }
    }
}
