using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

namespace Cutscene
{
    public class CutsceneHandler : MonoBehaviour
    {
        [Header("All cutscenes.")]
        [SerializeField] private List<GameObject> _cutscenes;

        public Action OnFinished;

        private Camera _startCamera;
        private Camera _cameraReplica;
        private Camera _currentCamera;

        private Cutscene _currentCutscene;

        private bool _isPlaying = false;


        private void Start()
        {
            _startCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
            _startCamera.enabled = true;

            for (int i = 0; i < Camera.allCamerasCount; ++i)
            {
                if(Camera.allCameras[i] != _startCamera) Camera.allCameras[i].enabled = false;
            }

            StartCutscene("Test");
        }


        public void StartCutscene(string cutsceneName)
        {
            if(!_isPlaying)
            {
                for(int i = 0; i < _cutscenes.Count; ++i)
                {
                    if (cutsceneName.ToLower() == _cutscenes[i].GetComponent<Cutscene>().GetName().ToLower())
                    {
                        _currentCutscene = _cutscenes[i].GetComponent<Cutscene>();
                        break;
                    }
                    else if(i == _cutscenes.Count-1) throw new Exception("Could not find cutscene!");
                }

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
            while(!_currentCutscene.IsFinished())
            {
                Transition transition = _currentCutscene.GetNextTransition();
                transition.Execute(this);

                await Task.Delay(transition.GetDelay());
            }

            Debug.Log("Cutscene finished!");

            // Reset everything
            _currentCamera.enabled = false;
            _startCamera.enabled = true;

            _cameraReplica = null;
            _currentCamera = null;

            Destroy(GameObject.Find("CameraReplica").gameObject);

            _currentCutscene.Reset();
            _currentCutscene = null;

            _isPlaying = false;

            try {
                OnFinished();
            } catch {
                // No functions assigned to action
                //Debug.Log(e.Message);
            }
        }

        public Camera GetCamera() { return _cameraReplica; }
        public Camera GetCurrentCamera() { return _currentCamera; }
        public void SetCurrentCamera(Camera cam) { _currentCamera = cam; }

    }
}

