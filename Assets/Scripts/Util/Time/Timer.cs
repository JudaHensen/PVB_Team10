using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CustomUtilities
{
    public class Timer
    {
        private float _startTime;
        private float _currentTime = 0;
        private float _maxTime = 1;
        private bool _active = true;
        private bool _hold = false;

        public Action OnComplete;
        public Action<float> OnCompleteOverflow;


        public Timer(float maxTime)
        {
            _startTime = Time.realtimeSinceStartup;
            _maxTime = maxTime;
        }

        public void Restart()
        {
            _startTime = Time.realtimeSinceStartup;
            _currentTime = 0;
            _hold = false;
        }

        public bool Completed()
        {
            if (_currentTime >= _maxTime) return true;
            return false;
        }

        public void SetActive(bool value) { _active = value; }

        public void SetTime(float time) { _maxTime = time; }

        public void Update()
        {
            if (_active && !_hold) _currentTime += Time.deltaTime;

            if (_currentTime >= _maxTime && !_hold)
            {
                _hold = true;
                try
                {
                    OnComplete();
                }
                catch { /* Nothing connected to this action, do nothing */ }

                try
                {
                    OnCompleteOverflow(_currentTime - _maxTime);
                }
                catch { /* Nothing connected to this action, do nothing */ }
            }
        }

    }
}

