using System.Collections.Generic;
using UnityEngine;

namespace Cutscene
{
    public class Transition : MonoBehaviour
    {
        [Header("Transition name for debugging.")]
        [SerializeField] private string _name;

        [Header("Transition time in miliseconds.")]
        [SerializeField] private int _length;

#region Move & Rotation

        [Header("If from is empty, move & rotate from curent camera transform.")]
        [Space(-10)]
        [Header("Move and rotate camera from & to a GameObjects transform.")]
        [SerializeField] private GameObject _moveFrom;

        [SerializeField] private GameObject _moveTo;

        [Header("Rotate to toTransform's rotation.")]
        [SerializeField] private bool _enableRotation = true;

        [Header("True if the object is a child of a moving object, false if the object is static.")]
        [SerializeField] private bool _local;

        [Header("Time in seconds to move and rotate.")]
        [SerializeField] public float _timespan;

#endregion

        [Header("If filled, make this the active camera.")]
        public Camera _camera;

        [Header("List of animations to play for this current transition.")]
        [SerializeField] private List<Cutscene.Animation> _animations;

        private AdjustCamera _cameraAdjuster;

        private Vector3 _positionSave;
        private Quaternion _rotationSave;

        private void Awake()
        {
            _cameraAdjuster = GameObject.Find("CutsceneManager").GetComponent<AdjustCamera>();
            if(_camera && _moveFrom)
            {
                _camera.transform.localPosition = _moveFrom.transform.localPosition;
                _camera.transform.localRotation = _moveFrom.transform.localRotation;
            }
        }

        public int GetDelay() { return _length + 50; }
        public string GetName() { return _name; }

        public void Execute(CutsceneHandler cutsceneHandler)
        {
            Debug.Log($"> Executing transition: {_name}");

            // Jump to new camera if needed
            if (!_moveFrom) _moveFrom = cutsceneHandler.GetCurrentCamera().gameObject;

            if (_camera)
            {
                cutsceneHandler.GetCurrentCamera().enabled = false;
                _camera.enabled = true;
                
                cutsceneHandler.SetCurrentCamera(_camera);
                _moveFrom = _camera.gameObject;
            }
            _cameraAdjuster.SetCamera(cutsceneHandler.GetCurrentCamera());

            // Save position and rotation for replay;
            _positionSave = _moveFrom.transform.localPosition;
            _rotationSave = _moveFrom.transform.localRotation;

            // Move & rotate camera if needed
            if (_moveTo)
            {
                _cameraAdjuster.Adjust(_moveFrom.transform, _moveTo.transform, _enableRotation, _local, _timespan);
            }

            // Trigger animations
            if (_animations.Count > 0)
            {
                for (int i = 0; i < _animations.Count; ++i)
                {
                    Cutscene.Animation anim = _animations[i];
                    anim.animator.SetTrigger(anim.triggerName);
                }
            }

        }

        public void Reset()
        {
            _moveFrom.transform.localPosition = _positionSave;
            _moveFrom.transform.localRotation = _rotationSave;
        }

    }
}

