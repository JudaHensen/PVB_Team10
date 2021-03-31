using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MineLocation : MonoBehaviour
{
    public string uniqueID;
    public Vector2 location;
    

    private void Start()
    {
        Debug.Log("Start mine");
        location = new Vector2(transform.position.x, transform.position.z);

        uniqueID = Guid.NewGuid().ToString();
        Debug.Log($"UniqueID: {uniqueID}");
    }
}
