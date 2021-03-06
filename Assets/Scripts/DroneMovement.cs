using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    private float SteerPower = 10f;
    private float Power = 1000f;
    private float rotationX = 0f;
    private float sensitivityY = 0f;

    public Transform Motor;

    public Rigidbody DroneRb;

    private Vector2 _movex = new Vector2();
    private Vector2 _movey = new Vector2();

    private InputManager _input;
    void Start()
    {
        _input = FindObjectOfType<InputManager>();
        DroneRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        Vector2 dirx = new Vector2(_input.StickLeft.x, 0f);
        Vector2 diry = new Vector2(0f, _input.StickLeft.y);
        _movex = dirx;
        _movey = diry;
        rotationX += _input.StickLeft.y;
        rotationX = Mathf.Clamp(rotationX, -30, 30);




        //Forward Movement
        DroneRb.AddForce(transform.forward * _input.TriggerRight * Power * Time.fixedDeltaTime);
        //Back Movement
        DroneRb.AddForce(transform.forward * -_input.TriggerLeft * Power * Time.fixedDeltaTime);
        // Steering left right
        DroneRb.transform.Rotate(Vector3.up * _input.StickLeft.x * SteerPower * Time.deltaTime);
        //Steering up down
        DroneRb.transform.Rotate(Vector3.right * -_input.StickLeft.y * SteerPower * Time.deltaTime);

        transform.localRotation = Quaternion.Euler(-rotationX, 0f, 0f);

    }
}
