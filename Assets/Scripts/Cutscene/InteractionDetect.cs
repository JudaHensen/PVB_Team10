using Controls;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractionDetect : MonoBehaviour
{
    private InputManager _input;
    private bool _isinteraction;
    [SerializeField] private GameObject _interactText;
    

    void Start()
    {
        _input = FindObjectOfType<InputManager>();
        _input.Interact += Interaction;

        _interactText = GameObject.Find("DiveText");
        _interactText.SetActive(false);
    }

    private void OnTriggerEnter(Collider col)
    {
        //Debug.Log($"Trigger enter: {col.gameObject.name}");

        if (col.CompareTag("Ship"))
        {
            _isinteraction = true;
            _interactText.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Ship"))
        {
            _isinteraction = false;
            _interactText.SetActive(false);
        }  
    }

    private void Interaction()
    {
        Debug.Log("Interact > dive");
        SceneSwitch sceneSwitch = GameObject.Find("SceneSwitch").GetComponent<SceneSwitch>();
        sceneSwitch.SwitchScene();
    }
}
