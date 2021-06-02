﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickTimeEventPosition : MonoBehaviour
{
    private ZeemijnDetectie _detected;

    private bool _isPositioning = false;
    private Transform _target;
    private float _distance = 2f;

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
            Vector3 targetPos = new Vector3(transform.position.x, _target.position.y, transform.position.z);
            Vector3 pos = Vector3.Lerp(transform.position, targetPos, 0.01f);
            transform.LookAt(_target);

            //Vector3.Distance(transform.position, _target.position);
            //_distance
        }
    }
}
