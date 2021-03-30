using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public Transform Motor;
    public float SteerPower = 0.05f;
    public float Power = 5f;
    public float MaxSpeed = 10f;

    public Rigidbody ShipRb;

    void Start()
    {
        ShipRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        var forceDirection = transform.forward;
        var Steer = 0;
        var StartPower = 0;

        if (Input.GetKey(KeyCode.A))
            Steer = 1;
        if (Input.GetKey(KeyCode.D))
            Steer = -1;
        if (Input.GetKey(KeyCode.W))
            StartPower = 1;

        ShipRb.AddForceAtPosition(Steer * transform.right * SteerPower , Motor.position);

        ShipRb.AddForceAtPosition(StartPower * transform.forward * Power, Motor.position);

        


    }
}
