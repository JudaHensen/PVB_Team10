 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Controls;

public class ZeemijnDetectie : MonoBehaviour
{
    private InputManager _input;
    public Action PlantExplosive;
    private bool _detectedMine = false;
    private bool _isInteracting = false;
    public Action<bool> CanInteract;
    public Action<Transform> InteractedMine;

    private Transform _mine;

    private void Awake()
    {
        _input = FindObjectOfType<InputManager>();
        _input.Interact += StartQuickTimeEvent;
    }

    private void SetDetection(bool state)
    {
        Debug.Log("Detection");
        CanInteract?.Invoke(state);
        _detectedMine = state;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag + " | " + other.name + " | " + _isInteracting);
        if(other.transform.tag == "Zeemijn" && !_isInteracting)
        {
            Debug.Log("Entered interaction range");
            SetDetection(true);
            _mine = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Zeemijn")
        {
            SetDetection(false);
            _mine = null;
        }
        
    }

    void StartQuickTimeEvent()
    {
        if (_detectedMine)
        {
            Debug.Log("Starting QTE");    
            _input.SetInputMode(ControllerInputMode.QUICK_TIME);
            InteractedMine?.Invoke(_mine);
            _isInteracting = true;
            SetDetection(false);
        }
    }
}


//private float _range = 5000f;

// Raycast Method

//RaycastHit hit;

//if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, _range))
//{
//    // Draw line in scene view to visualize raycast
//    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
//    _detectedMine = true;
//}
//else
//{
//    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * _range, Color.red);
//    _detectedMine = false;
//}