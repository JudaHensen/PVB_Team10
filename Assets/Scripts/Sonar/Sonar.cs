using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Sonar : MonoBehaviour
{
    [SerializeField]
    private float _width;

    [SerializeField]
    private float _height;

    [SerializeField]
    private float _depth;

    [SerializeField]
    private float _rotationSpeed;


    private void Start()
    {
        _width = _rotationSpeed / 24 * 2.5f;

        // Create Sonar mesh.
        SonarMesh sonarMesh = new SonarMesh(_width, _height, _depth, this.transform);
    }

    private void Update()
    {
        RotateSweeper();
    }

    private void RotateSweeper()
    {
        transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0, Space.Self);
    }

    // Update sonar user interface
    private void UpdateSonar()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Found collission!");

        if (collision.collider.name.ToString().ToLower() == "mine")
        {
            Debug.Log("Detected mine!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Found Trigger");
    }

}
