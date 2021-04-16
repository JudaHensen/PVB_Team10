using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

namespace Cutscene
{
    public class CutsceneHandler : MonoBehaviour
    {
        [Header("All transitions in chronological order.")]
        [SerializeField]
        private List<GameObject> _transitions;

        public Action OnFinished;

        private Camera _startCamera;
        private Camera _cameraReplica;
        private Camera _currentCamera;

        private bool _isPlaying = false;

        private void Start()
        {
            _startCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
            _startCamera.enabled = true;

            for (int i = 0; i < Camera.allCamerasCount; ++i)
            {
                if(Camera.allCameras[i] != _startCamera) Camera.allCameras[i].enabled = false;
            }

            GameObject.Find("InputHandler").GetComponent<InputManager>().Interact += StartCutscene;
        }


        public void StartCutscene()
        {
            if(!_isPlaying)
            {
                Debug.Log("Starting cutscene");
                _isPlaying = true;

                _startCamera.enabled = false;

                transform.position = _startCamera.transform.position;

                GameObject camParent = new GameObject("CameraReplica");
                camParent.transform.parent = transform;

                _cameraReplica = camParent.AddComponent<Camera>();
                _cameraReplica.CopyFrom(_startCamera);
                _cameraReplica.enabled = true;

                _currentCamera = _cameraReplica;

                ExecuteCutscene();
            }
        }

        private async void ExecuteCutscene()
        {
            for(int i = 0; i < _transitions.Count; ++i)
            {
                Transition transition = _transitions[i].GetComponent<Transition>();

                transition.Execute(this);
                await Task.Delay(transition.GetDelay());

                //Debug.Log($"Transition {transition.GetName()} finished.");
            }
            Debug.Log("Cutscene finished!");

            _currentCamera.enabled = false;
            _startCamera.enabled = true;

            _cameraReplica = null;
            _currentCamera = null;

            Destroy(transform.Find("CameraReplica").gameObject);

            for (int i = 0; i < _transitions.Count; ++i)
            {
                _transitions[i].GetComponent<Transition>().Reset();
            }

            _isPlaying = false;

            try {
                OnFinished();
            } catch(Exception e) {
                // No functions assigned to action
                Debug.Log(e.Message);
            }
        }

        public Camera GetCamera() { return _cameraReplica; }
        public Camera GetCurrentCamera() { return _currentCamera; }
        public void SetCurrentCamera(Camera cam) { _currentCamera = cam; }

    }
}

