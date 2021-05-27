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

        public float GetTime()
        {
            return _currentTime;
        }

        public float GetPercentage()
        {
            return _currentTime / _maxTime;
        }

        public string GetCountdown()
        {
            float time, minutes, seconds;

            time = _maxTime - _currentTime;
            minutes = Mathf.Ceil(time / 60)-1;
            seconds = Mathf.Floor(time % 60);

            if (minutes < 0) minutes = 0;
            if (seconds < 0) seconds = 0;

            if(seconds >= 10) return $"{minutes} : {seconds}";
            return $"{minutes} : 0{seconds}";
        }

    }
}

