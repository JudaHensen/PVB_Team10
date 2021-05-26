using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Controls;

public class InteractionUI : MonoBehaviour
{
    private InputManager _input;
    private ZeemijnDetectie _detectie;

    private Image _img;

    public Sprite ps;
    public Sprite xb;
    void Start()
    {
        _input = FindObjectOfType<InputManager>();
        _img = GetComponent<Image>();
        _detectie = FindObjectOfType<ZeemijnDetectie>();
        _detectie.canInteract += SetSprite;
    }

    // Update is called once per frame
    void SetSprite(bool state)
    {
        ControllerType _controllerType = _input.GetControllerType();
        
        if (_controllerType == ControllerType.PS4)
        {
            _img.sprite = ps;
        }
        else if (_controllerType == ControllerType.XBOX)
        {
            _img.sprite = xb;
        }
        else
        {
            Debug.LogError("Could Not Get Controller!");
        }

        _img.enabled = state;
        
    }
}
