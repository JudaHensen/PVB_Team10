using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    private float SteerPower = 100;
    private float Power = 1000f;

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




        //Forward Movement
        DroneRb.AddForce(transform.forward * _input.TriggerRight * Power * Time.fixedDeltaTime);
        //Back Movement
        DroneRb.AddForce(transform.forward * -_input.TriggerLeft * Power * Time.fixedDeltaTime);
        // Steering left right
        DroneRb.AddForceAtPosition(-_movex.x * transform.right * SteerPower * Time.fixedDeltaTime, Motor.position);
        //Steering up down
        DroneRb.AddForceAtPosition(-_movey.y * transform.up * SteerPower * Time.fixedDeltaTime, Motor.position);
    }
}
