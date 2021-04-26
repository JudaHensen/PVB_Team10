using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controls;

public class CameraSpeed : MonoBehaviour
{
    private InputManager _input;
    public Transform start;
    public Transform end;
    private float speed = 1;
    void Start()
    {
        _input = FindObjectOfType<InputManager>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.TriggerRight >= 0.1)
        {
            transform.position = Vector3.Lerp(start.position, end.position, speed * Time.deltaTime);
            Debug.Log("eeee");
        }
        if(_input.TriggerRight == 0)
        {
            transform.position = Vector3.Lerp(end.position, start.position, speed * Time.deltaTime);
        }
        
    }
}
