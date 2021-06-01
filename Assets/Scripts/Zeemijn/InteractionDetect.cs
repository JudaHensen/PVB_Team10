using Controls;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionDetect : MonoBehaviour
{
    private InputManager _input;
    private InteractionUI _ui;
    private bool _canInteract;

    void Start()
    {
        _input = FindObjectOfType<InputManager>();
        _ui = FindObjectOfType<InteractionUI>();

        _input.Interact += Interaction;
    }
    private void Interaction()
    {
        Debug.Log("Mine interaction: " + _canInteract);
        if (!_canInteract) { return; } // Als de speler niet in de buurt is van een zeemijn kan de drone niet duiken.
        _input.Interact -= Interaction;
        Debug.Log("Interact > dive");
        SceneSwitch sceneSwitch = GameObject.Find("SceneSwitch").GetComponent<SceneSwitch>();
        sceneSwitch.SwitchScene();
    }

    private void SetCanInteract(bool state)
    {
        _canInteract = state;
        _ui.SetSprite(state);
        Debug.Log("Can interact: " + state);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Ship"))
        {
            SetCanInteract(true);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Ship"))
        {
            SetCanInteract(false);
        }
    }

}
