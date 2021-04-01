using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class ShipMovement : MonoBehaviour
{
    private float SteerPower = 50f;
    private float Power = 1000000;

    public Transform Motor;

    public Rigidbody ShipRb;

    private Vector2 _move = new Vector2();

    private InputManager _input;
    void Start()
    {
        _input = FindObjectOfType<InputManager>();
        ShipRb = GetComponent<Rigidbody>();

        _input.Move += SetMove;
    }

    // Update is called once per frame
    private void SetMove(Vector2 _val)
    {
        _val.x /= 10;
        _move = _val;
        Debug.Log(_move);
    }
    private void FixedUpdate()
    {
        //Forward Movement
        ShipRb.AddForce(transform.forward * _move.y * Power * Time.fixedDeltaTime);
        
        // Steering Movement
        ShipRb.AddForceAtPosition(-_move.x * transform.right * SteerPower * Time.fixedDeltaTime, Motor.position);
        
        if(ShipRb.velocity.z == 0)
        {
            SteerPower = 0.1f;
        }
        else
        {
            SteerPower = 10f;
        }


    }
}
