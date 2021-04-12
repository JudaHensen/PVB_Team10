using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public enum QuickTimeInputKey { NORTH, EAST, SOUTH, WEST }

    public PlayerControls controls;

    public Vector2 StickLeft;
    public Vector2 StickRight;

    public float TriggerLeft;
    public float TriggerRight;

    public Action ToggleMenu;
    public Action Interact;
    
    public Action<QuickTimeInputKey> QuickTimeInput;


    void Awake()
    {

        controls = new PlayerControls();

        // Gameplay Inputs
        controls.Gameplay.Interact.performed += ctx => CallInteract();
        controls.Gameplay.OpenMenu.performed += ctx => CallToggleMenu();

        // TRIGGERS
        controls.Gameplay.TriggerLeft.performed += ctx => TriggerLeft = ctx.ReadValue<float>();
        controls.Gameplay.TriggerLeft.canceled += ctx => TriggerLeft = 0f;

        controls.Gameplay.TriggerRight.performed += ctx => TriggerRight = ctx.ReadValue<float>();
        controls.Gameplay.TriggerRight.canceled += ctx => TriggerRight = 0f;

        // STICKS
        controls.Gameplay.StickLeft.performed += ctx => StickLeft = ctx.ReadValue<Vector2>();
        controls.Gameplay.StickLeft.canceled += ctx => StickLeft = Vector2.zero;

        controls.Gameplay.StickRight.performed += ctx => StickRight = ctx.ReadValue<Vector2>();
        controls.Gameplay.StickRight.canceled += ctx => StickRight = Vector2.zero;

        // QuickTime event inputs
        controls.QuickTime.OpenMenu.performed += ctx => ToggleMenu();

        controls.QuickTime.Q1.performed += ctx => QuickTimeInput(QuickTimeInputKey.NORTH);
        controls.QuickTime.Q2.performed += ctx => QuickTimeInput(QuickTimeInputKey.EAST);
        controls.QuickTime.Q3.performed += ctx => QuickTimeInput(QuickTimeInputKey.SOUTH);
        controls.QuickTime.Q4.performed += ctx => QuickTimeInput(QuickTimeInputKey.WEST);
    }

    private void CallToggleMenu()
    {
        if(ToggleMenu != null)
        {
            ToggleMenu();
        }
    }

    private void CallInteract()
    {
        if(Interact != null)
        {
            Interact();
        }
    }


    // change input mapping depending on gameplay
    public void SetInputMode(InputMode mode)
    {
        switch (mode)
        {
            case InputMode.GAMEPLAY:
                controls.Gameplay.Enable();
                controls.QuickTime.Disable();
                Debug.Log("Set to GP");
                break;
            case InputMode.QUICK_TIME:
                controls.Gameplay.Disable();
                controls.QuickTime.Enable();
                Debug.Log("Set to QTE");
                break;
        }
    }

    private void OnEnable()
    {
         controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
         controls.Gameplay.Disable();
         controls.QuickTime.Disable();
    }
}
