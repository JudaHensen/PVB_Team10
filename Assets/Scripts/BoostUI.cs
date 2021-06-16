using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Controls;
using System;

public class BoostUI : MonoBehaviour
{
    private InputManager _input;

    public Image img;

    public Sprite ps;
    public Sprite xb;
    public DroneMovement _movement;
    void Start()
    {
        _input = FindObjectOfType<InputManager>();
        _movement = FindObjectOfType<DroneMovement>();
        
        SetSprite(false);
    }

    private void Update()
    {
        SetSprite(_movement.GetCanBoost() );
    }

    // Update is called once per frame
    public void SetSprite(bool state)
    {
        if (!img) { return; }

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
            img.color = new Color32(255, 255, 255, 255);
        }
        else
        {
            img.color = new Color32(85, 85, 95, 100);
        }
        
    }
}
