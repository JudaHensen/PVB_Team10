using Controls;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionDetect : MonoBehaviour
{
    private InputManager _input;
    private bool _canInteract;

    void Start()
    {
        _input = FindObjectOfType<InputManager>();
    
        _input.Interact += Interaction;
    }

    private void Interaction()
    {
        if (!_canInteract) { return; } // Als de speler niet in de buurt is van een zeemijn kan de drone niet duiken.
        _input.Interact -= Interaction;
        Debug.Log("Interact > dive");
        SceneSwitch sceneSwitch = GameObject.Find("SceneSwitch").GetComponent<SceneSwitch>();
        sceneSwitch.SwitchScene();
    }
}
