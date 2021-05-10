using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFloater : MonoBehaviour
{
    public Rigidbody boat;
    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 3f;

    private void FixedUpdate()
    {
        if(transform.position.y < 0f)
        {
            float displacementMultiplier = Mathf.Clamp01(-transform.position.y / depthBeforeSubmerged) * displacementAmount;
            boat.AddForce(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), ForceMode.Acceleration);
        }

    }
}
