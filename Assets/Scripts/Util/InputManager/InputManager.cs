using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

namespace Controls
{
    public class InputManager : MonoBehaviour
    {

        public PlayerControls controls;

        public Vector2 StickLeft;
        public Vector2 StickRight;

        public float TriggerLeft;
        public float TriggerRight;

        public Action ToggleMenu;
        public Action MenuInteract;
        public Action Interact;

        // Main Menu
        public Action AnyKey;
        public Action Back;

        public Action<QuickTimeInputKey> QuickTimeInput;

        public Action<ControllerInputMode> InputMode;
        public Action<ControllerType> UsedController;
        private ControllerType controllerUsed;
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
            controls.Gameplay.StickLeft.canceled += ctx => StickLeft = new Vector2();
            controls.Gameplay.StickRight.performed += ctx => StickRight = ctx.ReadValue<Vector2>();
            controls.Gameplay.StickRight.canceled += ctx => StickRight = new Vector2();

            // QuickTime event inputs
            controls.QuickTime.OpenMenu.performed += ctx => ToggleMenu();

            controls.QuickTime.Q1.performed += ctx => QuickTimeInput?.Invoke(QuickTimeInputKey.NORTH);
            controls.QuickTime.Q2.performed += ctx => QuickTimeInput?.Invoke(QuickTimeInputKey.EAST);
            controls.QuickTime.Q3.performed += ctx => QuickTimeInput?.Invoke(QuickTimeInputKey.SOUTH);
            controls.QuickTime.Q4.performed += ctx => QuickTimeInput?.Invoke(QuickTimeInputKey.WEST);

            // MainMenu Inputs
            controls.MainMenu.AnyKey.performed += ctx => AnyKey?.Invoke();
            controls.MainMenu.Interact.performed += ctx => MenuInteract?.Invoke();
            controls.MainMenu.Back.performed += ctx => Back?.Invoke();

            controls.MainMenu.StickLeft.performed += ctx => StickLeft = ctx.ReadValue<Vector2>();
            controls.MainMenu.StickLeft.canceled += ctx => StickLeft = new Vector2();

            // Start check voor controller
            CheckGamepad();
            InvokeRepeating("CheckGamepad", 1f, 1f);
            DontDestroyOnLoad(gameObject);
        }

        private void CheckGamepad()
        {
            try
            {
                Debug.Log(Gamepad.current.name);
            }
            catch
            {
                Debug.LogWarning("NO CONTROLLER FOUND! Error");
                return;
            }

            if (Gamepad.current.name.Contains("DualShock4"))
            {
                UsedController?.Invoke(ControllerType.PS4);
                controllerUsed = ControllerType.PS4;
            }
            else if (Gamepad.current.name.Contains("XInputController"))
            {
                UsedController?.Invoke(ControllerType.XBOX);
                controllerUsed = ControllerType.XBOX;
            }
        }

        // change input mapping depending on gameplay
        public void SetInputMode(ControllerInputMode mode)
        {
            controls.Gameplay.Disable();
            controls.QuickTime.Disable();
            controls.MainMenu.Disable();
            switch (mode)
            {
                case ControllerInputMode.GAMEPLAY:
                    controls.Gameplay.Enable();
                    Debug.Log("Set to GP");
                    break;
                case ControllerInputMode.QUICK_TIME:
                    controls.QuickTime.Enable();
                    Debug.Log("Set to QTE");
                    break;
                case ControllerInputMode.MAIN_MENU:
                    controls.MainMenu.Enable();
                    break;
            }

            InputMode?.Invoke(mode);

        }

        public ControllerType GetControllerType()
        {
            return controllerUsed;
        }

        private void OnEnable()
        {
            controls.MainMenu.Enable();
        }

        private void OnDisable()
        {
            controls.Gameplay.Disable();
            controls.QuickTime.Disable();
            controls.MainMenu.Disable();
        }
    }
}