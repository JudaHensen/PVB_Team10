using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

namespace Cutscene
{
    public class Transition : MonoBehaviour
    {
        [Header("Transition name for debugging.")]
        [SerializeField] private string _name;

        [Header("Transition time in miliseconds.")]
        [SerializeField] protected uint _length;

#region Move & Rotation

        [Header("If from is empty, move & rotate from curent camera transform.")]
        [Space(-10)]
        [Header("Move and rotate camera from & to a GameObjects transform.")]
        [SerializeField] protected GameObject _moveFrom;

        [SerializeField] protected GameObject _moveTo;

        [Header("Rotate to toTransform's rotation.")]
        [SerializeField] protected bool _enableRotation = true;

        [Header("True if the object is a child of a moving object, false if the object is static.")]
        [SerializeField] protected bool _local = false;

        [Header("Make camera a child of this gameobject, if it isn't already.")]
        [SerializeField] protected bool _makeParent = false;

        [Header("Time in seconds to move and rotate.")]
        [SerializeField] protected float _timespan;

        [Header("If filled, make this the active camera.")]
        [SerializeField] protected Camera _camera;

        // Save the base position to avoid movement & rotation errors.
        protected Vector3 _positionSave;
        protected Quaternion _rotationSave;

#endregion

        [Header("List of animations to play for this current transition.")]
        [SerializeField] private List<Cutscene.Animation> _animations;

        protected AdjustCamera _cameraAdjuster;
        

        protected virtual void Awake()
        {
            _cameraAdjuster = GameObject.Find("CutsceneManager").GetComponent<AdjustCamera>();
            if(_camera && _moveFrom)
            {
                _camera.transform.localPosition = _moveFrom.transform.localPosition;
                _camera.transform.localRotation = _moveFrom.transform.localRotation;
            }
        }

        public virtual void Execute(CutsceneHandler cutsceneHandler)
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

            if(_makeParent && !_camera)
            {
                cutsceneHandler.GetCurrentCamera().transform.parent = transform;
            }

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
                    TriggerAnimation(_animations[i]);
                }
            }
        }

        // Trigger an animation after it's delay
        protected virtual async void TriggerAnimation(Cutscene.Animation anim)
        {
            await Task.Delay((int) anim.triggerDelay);
            anim.animator.SetTrigger(anim.triggerName);
        }

        // Reset positions
        public virtual void Reset()
        {
            _moveFrom.transform.localPosition = _positionSave;
            _moveFrom.transform.localRotation = _rotationSave;
        }

        // Add 2.5 frames extra delay to avoid errors in the adjust camera script.
        public int GetDelay() { return (int) _length + (int) Mathf.Floor(1000/20); }
        public string GetName() { return _name; }

    }
}

