using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cutscene
{
    public class AdjustCamera : MonoBehaviour
    {
        private Vector3 _startPosition;
        private Quaternion _startRotation;
        private Vector3 _endPosition;
        private Quaternion _endRotation;
        private bool _rotate;
        private bool _local;

        private CustomUtilities.Timer _timer;
        private bool _isActive = false;
        private float _lerpTime;

        private Camera _camera;

        public void SetCamera(Camera camera) { _camera = camera; }
        public Camera GetCamera() { return _camera; }


        public void Adjust(Transform from, Transform to, bool rotate, bool local, float time)
        {
            _local = local;
            if(_local)
            {
                _startPosition = from.localPosition;
                _startRotation = from.localRotation;

                _endPosition = to.localPosition;
                _endRotation = to.localRotation;
            }
            else
            {
                _startPosition = from.position;
                _startRotation = from.rotation;

                _endPosition = to.position;
                _endRotation = to.rotation;
            }

            _rotate = rotate;

            _lerpTime = time;
            _timer = new CustomUtilities.Timer(_lerpTime);

            _isActive = true;
        }

        void Update()
        {
            if(_isActive)
            {
                if(_timer.Completed()) {
                    if(_local)
                    {
                        _camera.transform.localPosition = _endPosition;
                        _camera.transform.localRotation = _endRotation;
                    }
                    else
                    {
                        _camera.transform.position = _endPosition;
                        _camera.transform.rotation = _endRotation;
                    }
                    
                    _isActive = false;
                }
                else {
                    _timer.Update();

                    float interpolation = _timer.GetTime() / _lerpTime;

                    if(_local)
                    {
                        _camera.transform.localPosition = Vector3.Lerp(_startPosition, _endPosition, interpolation);
                        if (_rotate) _camera.transform.localRotation = Quaternion.Lerp(_startRotation, _endRotation, interpolation);
                    } else
                    {
                        _camera.transform.position = Vector3.Lerp(_startPosition, _endPosition, interpolation);
                        if (_rotate) _camera.transform.rotation = Quaternion.Lerp(_startRotation, _endRotation, interpolation);
                    }

                    
                }
            }
        }

    }
}

