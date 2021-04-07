using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeemijnDetectie : MonoBehaviour
{
    private InputManager _input;
    private float _range = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, _range))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            Debug.Log(hit.transform.name);
        }

    }
}
