using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelTransition
{
    public class AdjustCamera : MonoBehaviour
    {
        [SerializeField]
        private GameObject _camera;

        private Vector3 _startPosition;
        private Vector3 _startRotation;

        private Vector3 _endPosition;
        private Vector3 _endRotation;

        //private CustomUtilities.Timer _timer;
        private bool _isActive = false;
        private float _lerpTime;

        public void Adjust(Vector3 position, Vector3 rotation, float time)
        {
            _startPosition = _camera.transform.position;
            _startRotation = new Vector3(_camera.transform.rotation.x, _camera.transform.rotation.y, _camera.transform.rotation.z);

            _endPosition = position;
            _endRotation = rotation;

            _lerpTime = time;
            //_timer = new CustomUtilities.Timer(_lerpTime);

            _isActive = true;
        }

        void Update()
        {
            if(_isActive)
            {
                /*
                if(_timer.Completed()) {
                    _camera.transform.position = _endPosition;
                    _camera.transform.rotation = _endRotation;
                    _isActive = false;
                }
                else {
                    _timer.Update();

                    float interpolation = _timer.GetTime() / _lerpTime;

                    _camera.transform. = Vector3.Lerp(_startPosition, _endPosition, interpolation);
                    _camera.transform.rotation = Quaternion.Lerp(_startRotation, _endRotation, interpolation);
                }
                */
            }
        }

    }
}

