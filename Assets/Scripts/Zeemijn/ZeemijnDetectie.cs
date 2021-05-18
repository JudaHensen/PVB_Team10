 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Controls;

public class ZeemijnDetectie : MonoBehaviour
{
    private InputManager _input;
    public Action PlantExplosive;
    private bool detectedMine = false;
    
    public Action<bool> canInteract;

    private void Start()
    {
        _input = FindObjectOfType<InputManager>();
        _input.Interact += StartQuickTimeEvent;
    }

    private void SetDetection(bool state)
    {
        canInteract?.Invoke(state);
        detectedMine = state;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "Zeemijn")
        {
            SetDetection(true);
            Debug.Log("Got one");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Zeemijn")
        {
            SetDetection(false);
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


//private float _range = 5000f;

// Raycast Method

//RaycastHit hit;

//if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, _range))
//{
//    // Draw line in scene view to visualize raycast
//    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
//    detectedMine = true;
//}
//else
//{
//    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * _range, Color.red);
//    detectedMine = false;
//}