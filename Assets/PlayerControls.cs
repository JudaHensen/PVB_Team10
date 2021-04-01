// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""72783af8-d71f-4750-a917-d422ba065309"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""f633f6c3-27fa-4f70-8548-34102da44124"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""37489fea-c9fb-4060-bc52-af20033f9cd7"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""28d5dc99-dbe6-4965-9620-002e8a1b5bc4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OpenMenu"",
                    ""type"": ""Button"",
                    ""id"": ""43908157-3dc6-4db7-876d-88007614aa65"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""093cf1f8-8fd7-40ae-b457-db9b4e54bb23"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc9ec492-1ba0-4e10-821e-711798aca092"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b249560-2e22-46f8-8022-3d31875d6463"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e550c73-3a94-4974-85c0-04f8d47b70fe"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""QuickTime"",
            ""id"": ""3518bdaf-9a0a-43e0-8e7b-33e71587d181"",
            ""actions"": [
                {
                    ""name"": ""Q1"",
                    ""type"": ""Button"",
                    ""id"": ""0a58e5c8-72af-4e0f-afb9-acee54bfba53"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Q2"",
                    ""type"": ""Button"",
                    ""id"": ""50b5fe25-fd3d-49e8-88d1-97122e41d5ae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Q3"",
                    ""type"": ""Button"",
                    ""id"": ""72be93c6-e5ba-4ed5-968d-44d5aa388427"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Q4"",
                    ""type"": ""Button"",
                    ""id"": ""d5396551-4a1c-4539-93bd-a0845bc9ec01"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OpenMenu"",
                    ""type"": ""Button"",
                    ""id"": ""76997f98-c9c5-480f-b082-1397349f15cf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""697b0a3a-0e80-4ec7-a1ef-1a1d565e7b19"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Q1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""764841d6-9110-47bf-9340-27836908357d"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Q2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2cbcaddf-b13c-4776-a554-c79589194a2c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Q3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""70ad1e5a-ffca-494c-b508-be306963da5d"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Q4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d9821d2-cbf9-4bd0-a0d2-33df7db1ea6c"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_Rotate = m_Gameplay.FindAction("Rotate", throwIfNotFound: true);
        m_Gameplay_Interact = m_Gameplay.FindAction("Interact", throwIfNotFound: true);
        m_Gameplay_OpenMenu = m_Gameplay.FindAction("OpenMenu", throwIfNotFound: true);
        // QuickTime
        m_QuickTime = asset.FindActionMap("QuickTime", throwIfNotFound: true);
        m_QuickTime_Q1 = m_QuickTime.FindAction("Q1", throwIfNotFound: true);
        m_QuickTime_Q2 = m_QuickTime.FindAction("Q2", throwIfNotFound: true);
        m_QuickTime_Q3 = m_QuickTime.FindAction("Q3", throwIfNotFound: true);
        m_QuickTime_Q4 = m_QuickTime.FindAction("Q4", throwIfNotFound: true);
        m_QuickTime_OpenMenu = m_QuickTime.FindAction("OpenMenu", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_Rotate;
    private readonly InputAction m_Gameplay_Interact;
    private readonly InputAction m_Gameplay_OpenMenu;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Rotate => m_Wrapper.m_Gameplay_Rotate;
        public InputAction @Interact => m_Wrapper.m_Gameplay_Interact;
        public InputAction @OpenMenu => m_Wrapper.m_Gameplay_OpenMenu;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Rotate.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotate;
                @Interact.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @OpenMenu.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOpenMenu;
                @OpenMenu.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOpenMenu;
                @OpenMenu.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOpenMenu;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @OpenMenu.started += instance.OnOpenMenu;
                @OpenMenu.performed += instance.OnOpenMenu;
                @OpenMenu.canceled += instance.OnOpenMenu;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // QuickTime
    private readonly InputActionMap m_QuickTime;
    private IQuickTimeActions m_QuickTimeActionsCallbackInterface;
    private readonly InputAction m_QuickTime_Q1;
    private readonly InputAction m_QuickTime_Q2;
    private readonly InputAction m_QuickTime_Q3;
    private readonly InputAction m_QuickTime_Q4;
    private readonly InputAction m_QuickTime_OpenMenu;
    public struct QuickTimeActions
    {
        private @PlayerControls m_Wrapper;
        public QuickTimeActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Q1 => m_Wrapper.m_QuickTime_Q1;
        public InputAction @Q2 => m_Wrapper.m_QuickTime_Q2;
        public InputAction @Q3 => m_Wrapper.m_QuickTime_Q3;
        public InputAction @Q4 => m_Wrapper.m_QuickTime_Q4;
        public InputAction @OpenMenu => m_Wrapper.m_QuickTime_OpenMenu;
        public InputActionMap Get() { return m_Wrapper.m_QuickTime; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(QuickTimeActions set) { return set.Get(); }
        public void SetCallbacks(IQuickTimeActions instance)
        {
            if (m_Wrapper.m_QuickTimeActionsCallbackInterface != null)
            {
                @Q1.started -= m_Wrapper.m_QuickTimeActionsCallbackInterface.OnQ1;
                @Q1.performed -= m_Wrapper.m_QuickTimeActionsCallbackInterface.OnQ1;
                @Q1.canceled -= m_Wrapper.m_QuickTimeActionsCallbackInterface.OnQ1;
                @Q2.started -= m_Wrapper.m_QuickTimeActionsCallbackInterface.OnQ2;
                @Q2.performed -= m_Wrapper.m_QuickTimeActionsCallbackInterface.OnQ2;
                @Q2.canceled -= m_Wrapper.m_QuickTimeActionsCallbackInterface.OnQ2;
                @Q3.started -= m_Wrapper.m_QuickTimeActionsCallbackInterface.OnQ3;
                @Q3.performed -= m_Wrapper.m_QuickTimeActionsCallbackInterface.OnQ3;
                @Q3.canceled -= m_Wrapper.m_QuickTimeActionsCallbackInterface.OnQ3;
                @Q4.started -= m_Wrapper.m_QuickTimeActionsCallbackInterface.OnQ4;
                @Q4.performed -= m_Wrapper.m_QuickTimeActionsCallbackInterface.OnQ4;
                @Q4.canceled -= m_Wrapper.m_QuickTimeActionsCallbackInterface.OnQ4;
                @OpenMenu.started -= m_Wrapper.m_QuickTimeActionsCallbackInterface.OnOpenMenu;
                @OpenMenu.performed -= m_Wrapper.m_QuickTimeActionsCallbackInterface.OnOpenMenu;
                @OpenMenu.canceled -= m_Wrapper.m_QuickTimeActionsCallbackInterface.OnOpenMenu;
            }
            m_Wrapper.m_QuickTimeActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Q1.started += instance.OnQ1;
                @Q1.performed += instance.OnQ1;
                @Q1.canceled += instance.OnQ1;
                @Q2.started += instance.OnQ2;
                @Q2.performed += instance.OnQ2;
                @Q2.canceled += instance.OnQ2;
                @Q3.started += instance.OnQ3;
                @Q3.performed += instance.OnQ3;
                @Q3.canceled += instance.OnQ3;
                @Q4.started += instance.OnQ4;
                @Q4.performed += instance.OnQ4;
                @Q4.canceled += instance.OnQ4;
                @OpenMenu.started += instance.OnOpenMenu;
                @OpenMenu.performed += instance.OnOpenMenu;
                @OpenMenu.canceled += instance.OnOpenMenu;
            }
        }
    }
    public QuickTimeActions @QuickTime => new QuickTimeActions(this);
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnOpenMenu(InputAction.CallbackContext context);
    }
    public interface IQuickTimeActions
    {
        void OnQ1(InputAction.CallbackContext context);
        void OnQ2(InputAction.CallbackContext context);
        void OnQ3(InputAction.CallbackContext context);
        void OnQ4(InputAction.CallbackContext context);
        void OnOpenMenu(InputAction.CallbackContext context);
    }
}
