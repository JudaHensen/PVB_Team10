using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Timer: MonoBehaviour
{
    private float _time;
    private float _currentTime;
    private bool _active;

    public event Action OnComplete;
    public event Action<float> OnCompleteOvertime;


    Timer(float time)
    {
        _time = time;
        _currentTime = 0;
        _active = false;
    }

    public void Start()
    {
        _active = true;
    }

    public void Stop()
    {
        _active = false;
    }

    public void Reset()
    {
        _currentTime = 0;
    }

    public void SetTime(float time)
    {
        _time = time;
    }

    void Update()
    {
        if (_active)
        {
            _currentTime += Time.deltaTime;

            if(_currentTime > _time)
            {
                _active = false;
                OnComplete();
                OnCompleteOvertime( _currentTime - _time );
            }
        }
    }
}
