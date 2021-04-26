using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpeed : MonoBehaviour
{
    private InputManager _input;
    Camera camera;
    void Start()
    {
        _input = FindObjectOfType<InputManager>();
        camera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
