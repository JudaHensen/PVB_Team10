using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField]
    private float SteerPower = 50f;
    [SerializeField]
    private float Power = 1000f;

    public Transform Motor;

    public Rigidbody ShipRb;

    void Start()
    {
        ShipRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    private void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        ShipRb.AddForceAtPosition(transform.right * h/-1 * SteerPower * Time.fixedDeltaTime, Motor.position);
        ShipRb.AddForce(transform.forward * v * Power * Time.fixedDeltaTime);

        Debug.Log(ShipRb.velocity);

        


    }
}
