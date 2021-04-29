using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MineLocation : MonoBehaviour
{
    public string uniqueID;
    public Vector2 location;

    [SerializeField]
    private bool _visible;

    private void Start()
    {
        location = new Vector2(transform.position.x, transform.position.z);

        uniqueID = Guid.NewGuid().ToString();

      //  GetComponent<MeshRenderer>().enabled = _visible;
    }

    private void Update()
    {
        location = new Vector2(transform.position.x, transform.position.z);
    }
}
