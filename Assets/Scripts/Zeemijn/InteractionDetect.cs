using Controls;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionDetect : MonoBehaviour
{
    private InputManager _input;
    private bool _canInteract;

    //[SerializeField]
    //private GameObject _interactText;
    
    [SerializeField]
    private Image _img;
    [SerializeField]
    private Sprite _diveImg;
    [SerializeField]
    private Sprite _diveImgGray;

    void Start()
    {
        _input = FindObjectOfType<InputManager>();
        _input.Interact += Interaction;

        ////_interactText = GameObject.Find("DiveText");
        ////_interactText.SetActive(false);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Ship"))
        {
            SetUI(true);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Ship"))
        {
            SetUI(false);
        }  
    }

    private void SetUI(bool state)
    {
        if (state)
        {
            _img.sprite = _diveImg;
            _canInteract = true;
        }
        else
        {
            _img.sprite = _diveImgGray;
            _canInteract = false;
        }
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
