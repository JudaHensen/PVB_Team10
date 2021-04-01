using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArea : MonoBehaviour
{
    Vector3 shipPosition;
    Vector3 minPosition;
    Vector3 maxPosition;
    bool IsInArea = true;

    void Start()
    {
        Vector3 shipPosition = GameObject.Find("Ship").transform.position;
        Vector3 minPosition = new Vector3(1, 0f, 1f);
        Vector3 maxPosition = new Vector3(-1f, 0f, -1f);

        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 3 && IsInArea; ++i)
        {
            if (shipPosition[i] < minPosition[i] || shipPosition[i] > maxPosition[i])
                IsInArea = false;
        }
        if(IsInArea == false)
        {
            print("you left the area");
        }
    }
        
}
