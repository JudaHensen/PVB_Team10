using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

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
        controls.Gameplay.Interact.performed += ctx => Interact?.Invoke(); // ?.Invoke() Check of de Action wel gebruikt wordt om errors te voorkomen.
        controls.Gameplay.OpenMenu.performed += ctx => ToggleMenu?.Invoke();

        controls.Gameplay.TriggerLeft.performed += ctx => TriggerLeft = ctx.ReadValue<float>();
        controls.Gameplay.TriggerLeft.canceled += ctx => TriggerLeft = 0f;
        controls.Gameplay.TriggerRight.performed += ctx => TriggerRight = ctx.ReadValue<float>();
        controls.Gameplay.TriggerRight.canceled += ctx => TriggerRight = 0f;

        controls.Gameplay.StickLeft.performed += ctx => StickLeft = ctx.ReadValue<Vector2>();
        controls.Gameplay.StickRight.performed += ctx => StickRight = ctx.ReadValue<Vector2>();

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
