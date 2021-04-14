using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelTransition
{
    public class LevelTransition : MonoBehaviour
    {

        //[SerializeField]
        //private string _sceneToLoad;
        //[SerializeField]
        //private GameObject _transitionObject;

        [SerializeField]
        private GameObject _rotateTo;
        [SerializeField]
        private float _rotateTime = 1f;

        private InputManager _input;

        private void Start()
        {
            _input = GameObject.Find("InputHandler").GetComponent<InputManager>();
            _input.Interact += OnInteract;
            //Debug.Log(_input);
        }

        private void OnInteract()
        {
            GetComponent<AdjustCamera>().Adjust(_rotateTo.transform.position, _rotateTo.transform.rotation, _rotateTime);

            //Debug.Log("Interact!");
            //DontDestroyOnLoad(_transitionObject);

            //SceneManager.LoadScene(_sceneToLoad);
        }

    }
}


