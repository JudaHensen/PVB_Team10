using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public enum InputMode { GAMEPLAY, QUICK_TIME }
    public enum QuickTimeInputKey { NORTH, EAST, SOUTH, WEST }

    public PlayerControls controls;

    public Action<Vector2> StickLeft;
    public Action<Vector2> StickRight;

    public Action<float> TriggerLeft;
    public Action<float> TriggerRight;

    public Action ToggleMenu;
    public Action Interact;
    
    public Action<QuickTimeInputKey> QuickTimeInput;

    void Awake()
    {
        controls = new PlayerControls();

        // Gameplay Inputs
        controls.Gameplay.Interact.performed += ctx => Interact();
        controls.Gameplay.OpenMenu.performed += ctx => ToggleMenu();

        controls.Gameplay.TriggerLeft.performed += ctx => LeftTrigger(ctx.ReadValue<float>());
        controls.Gameplay.TriggerRight.performed += ctx => RightTrigger(ctx.ReadValue<float>());

        controls.Gameplay.StickLeft.performed += ctx => StickLeft(ctx.ReadValue<Vector2>());
        controls.Gameplay.StickRight.performed += ctx => StickRight(ctx.ReadValue<Vector2>());

        // QuickTime event inputs
        controls.QuickTime.OpenMenu.performed += ctx => ToggleMenu();

        controls.QuickTime.Q1.performed += ctx => QuickTimeInput(QuickTimeInputKey.NORTH);
        controls.QuickTime.Q2.performed += ctx => QuickTimeInput(QuickTimeInputKey.EAST);
        controls.QuickTime.Q3.performed += ctx => QuickTimeInput(QuickTimeInputKey.SOUTH);
        controls.QuickTime.Q4.performed += ctx => QuickTimeInput(QuickTimeInputKey.WEST);
    }

    // change input mapping depending on gameplay
    public void SetInputMode(InputMode mode)
    {
        switch (mode)
        {
            case InputMode.GAMEPLAY:
                controls.Gameplay.Enable();
                controls.QuickTime.Disable();
                break;
            case InputMode.QUICK_TIME:
                controls.Gameplay.Disable();
                controls.QuickTime.Enable();
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
