using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeDetection : MonoBehaviour
{

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Ship"))
        {
            Destroy(col.gameObject);
            Debug.Log("Ship exploded!");
        }
    }
}
