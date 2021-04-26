using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Controls;

public class ZeemijnDetectie : MonoBehaviour
{
    private InputManager _input;
    private float _range = 5000f;
    public Action PlantExplosive;
    private bool detectedMine = false;

    private void Start()
    {
        _input = FindObjectOfType<InputManager>();
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
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * _range, Color.red);
            detectedMine = false;
        }
    }

    void StartQuickTimeEvent()
    {
        if (detectedMine)
        {
            _input.SetInputMode(ControllerInputMode.QUICK_TIME);
        }
    }
}
