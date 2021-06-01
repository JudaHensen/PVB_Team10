using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Controls;
using System;

public class InteractionUI : MonoBehaviour
{
    private InputManager _input;
    private ZeemijnDetectie _detectie;

    public Image img;

    public Sprite ps;
    public Sprite xb;
    void Start()
    {
        _input = FindObjectOfType<InputManager>();
        _detectie = FindObjectOfType<ZeemijnDetectie>();
        _detectie.CanInteract += SetSprite;
        SetSprite(false);
    }

    // Update is called once per frame
    void SetSprite(bool state)
    {
        ControllerType _controllerType = _input.GetControllerType();
        
        if (_controllerType == ControllerType.PS4)
        {
            img.sprite = ps;
        }
        else if (_controllerType == ControllerType.XBOX)
        {
            img.sprite = xb;
        }
        else
        {
            Debug.LogError("Could Not Get Controller!");
        }

        if (state)
        {
            img.color = new Color(255f, 255f, 255f, 0.8f);
        }
        else
        {
            img.color = Color.white;
        }
        
    }
}
