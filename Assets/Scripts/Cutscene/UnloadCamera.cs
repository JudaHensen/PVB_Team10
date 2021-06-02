using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnloadCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Camera>().enabled = false;
    }
}
