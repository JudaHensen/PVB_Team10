using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickTimeEventPosition : MonoBehaviour
{
    private ZeemijnDetectie _detected;

    private bool _isPositioning = false;
    private Transform _target;
    private float _distance = 2f;
    private float _yPosOffset = 5f;
    private float _yLookOffset = 4f;
    void Start()
    {
        _detected = GetComponent<ZeemijnDetectie>();
        _detected.InteractedMine += SetPosition;
    }

    private void SetPosition(Transform obj)
    {
        _isPositioning = true;

        _target = obj;
    }

    void Update()
    {
        if (_isPositioning)
        {
            Vector3 targetPos = new Vector3(transform.position.x, _target.position.y + _yPosOffset, transform.position.z);
            Vector3 pos = Vector3.Lerp(transform.position, targetPos, 0.1f);

            transform.position = pos;
            transform.LookAt(_target.position + new Vector3(0f, _yLookOffset, 0f));

            if(Vector3.Distance(transform.position, _target.position) > _distance)
            {
                Vector3 distancePos = new Vector3(_target.position.x, 0f, _target.position.z);
                Vector3.Lerp(transform.position, distancePos, 0.01f);
            }

        }
    }
}
