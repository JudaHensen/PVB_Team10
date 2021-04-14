using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{

    [SerializeField]
    private string _sceneToLoad;
    [SerializeField]
    private GameObject _transitionObject;

    private InputManager _input;

    private void Start()
    {
        _input = GameObject.Find("InputHandler").GetComponent<InputManager>();
        _input.Interact += OnInteract;
        Debug.Log(_input);
    }

    private void OnInteract()
    {
        Debug.Log("Interact!");
        DontDestroyOnLoad(_transitionObject);

        SceneManager.LoadScene(_sceneToLoad);
    }

}
