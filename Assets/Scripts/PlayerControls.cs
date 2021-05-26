// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerControls.inputactions'

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
                    ""name"": ""TriggerLeft"",
                    ""type"": ""Value"",
                    ""id"": ""f633f6c3-27fa-4f70-8548-34102da44124"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TriggerRight"",
                    ""type"": ""Value"",
                    ""id"": ""3f60351f-f49a-4390-80be-058427c934cf"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StickRight"",
                    ""type"": ""Value"",
                    ""id"": ""37489fea-c9fb-4060-bc52-af20033f9cd7"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StickLeft"",
                    ""type"": ""Value"",
                    ""id"": ""88225ac6-fed2-4ae0-ae72-7267156b9dc1"",
                    ""expectedControlType"": ""Vector2"",
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
                    ""type"": ""PassThrough"",
                    ""id"": ""43908157-3dc6-4db7-876d-88007614aa65"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""093cf1f8-8fd7-40ae-b457-db9b4e54bb23"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TriggerLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc9ec492-1ba0-4e10-821e-711798aca092"",
                    ""path"": ""<Gamepad>/buttonWest"",
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
                    ""action"": ""StickRight"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""016f4042-2abd-4c7c-a6e0-bfe936cb8ce1"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StickLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f9f0057-2f3b-4b0f-a243-b00a1128a646"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TriggerRight"",
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
        },
        {
            ""name"": ""MainMenu"",
            ""id"": ""fcb9aedd-ad31-493a-9a9f-0357629ba0b2"",
            ""actions"": [
                {
                    ""name"": ""AnyKey"",
                    ""type"": ""Value"",
                    ""id"": ""c07c9997-6129-4a93-a242-6bda1ea76d08"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""5ba2d04f-f715-467e-963a-0d0c30e3205c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StickLeft"",
                    ""type"": ""Value"",
                    ""id"": ""4b0fff7f-3a66-4889-980b-a706ce828071"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""d7abdf91-73c5-48d0-8e32-4d74069b9ecf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""58c71a2d-f328-46d6-81f1-d116f8b22e25"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StickLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""52c5b5a5-b343-42ee-9c81-67f4baaace47"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""AnyKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a53bc5a2-05e6-4715-a885-f2bca5bf92f6"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""AnyKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""74eebc39-1ebd-4b08-820d-e827a602962c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""AnyKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7ad5967-62d7-4a1b-8457-bbe9f87d0a6c"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""AnyKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0fd22e5-636e-47a7-9492-418699ee1aa7"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""AnyKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a060ea9-3a80-418a-865f-370430d7235e"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""AnyKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c8c95ce-1773-46d0-8980-2e85fa89649e"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""AnyKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24b80b6b-c17f-4ee9-8a8a-91428c5cace1"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""AnyKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""38bd0af1-1ae3-470f-88e1-434b475abe2f"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""AnyKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d402ded8-6f1b-4674-9d41-b8bf1348553c"",
                    ""path"": ""<DualShockGamepad>/touchpadButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""AnyKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc8f073e-75e2-4a62-b63a-66019221389e"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""AnyKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""88a0d669-40b6-42b5-8218-0738c0487257"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""AnyKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d6b021d6-e959-4778-b5bd-8e69d7c252dc"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""AnyKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""11bc78a5-f95a-4bd9-8d18-4b78cfcf7d1b"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""AnyKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9d20cb9-f683-4d45-8db2-e47b1fd062e0"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8be91ca-353a-43fd-904a-ec2747778211"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cdb889a8-b37c-4976-95e7-02b0c2005ea4"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_TriggerLeft = m_Gameplay.FindAction("TriggerLeft", throwIfNotFound: true);
        m_Gameplay_TriggerRight = m_Gameplay.FindAction("TriggerRight", throwIfNotFound: true);
        m_Gameplay_StickRight = m_Gameplay.FindAction("StickRight", throwIfNotFound: true);
        m_Gameplay_StickLeft = m_Gameplay.FindAction("StickLeft", throwIfNotFound: true);
        m_Gameplay_Interact = m_Gameplay.FindAction("Interact", throwIfNotFound: true);
        m_Gameplay_OpenMenu = m_Gameplay.FindAction("OpenMenu", throwIfNotFound: true);
        // QuickTime
        m_QuickTime = asset.FindActionMap("QuickTime", throwIfNotFound: true);
        m_QuickTime_Q1 = m_QuickTime.FindAction("Q1", throwIfNotFound: true);
        m_QuickTime_Q2 = m_QuickTime.FindAction("Q2", throwIfNotFound: true);
        m_QuickTime_Q3 = m_QuickTime.FindAction("Q3", throwIfNotFound: true);
        m_QuickTime_Q4 = m_QuickTime.FindAction("Q4", throwIfNotFound: true);
        m_QuickTime_OpenMenu = m_QuickTime.FindAction("OpenMenu", throwIfNotFound: true);
        // MainMenu
        m_MainMenu = asset.FindActionMap("MainMenu", throwIfNotFound: true);
        m_MainMenu_AnyKey = m_MainMenu.FindAction("AnyKey", throwIfNotFound: true);
        m_MainMenu_Interact = m_MainMenu.FindAction("Interact", throwIfNotFound: true);
        m_MainMenu_StickLeft = m_MainMenu.FindAction("StickLeft", throwIfNotFound: true);
        m_MainMenu_Back = m_MainMenu.FindAction("Back", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_TriggerLeft;
    private readonly InputAction m_Gameplay_TriggerRight;
    private readonly InputAction m_Gameplay_StickRight;
    private readonly InputAction m_Gameplay_StickLeft;
    private readonly InputAction m_Gameplay_Interact;
    private readonly InputAction m_Gameplay_OpenMenu;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @TriggerLeft => m_Wrapper.m_Gameplay_TriggerLeft;
        public InputAction @TriggerRight => m_Wrapper.m_Gameplay_TriggerRight;
        public InputAction @StickRight => m_Wrapper.m_Gameplay_StickRight;
        public InputAction @StickLeft => m_Wrapper.m_Gameplay_StickLeft;
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
                @TriggerLeft.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTriggerLeft;
                @TriggerLeft.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTriggerLeft;
                @TriggerLeft.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTriggerLeft;
                @TriggerRight.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTriggerRight;
                @TriggerRight.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTriggerRight;
                @TriggerRight.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTriggerRight;
                @StickRight.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStickRight;
                @StickRight.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStickRight;
                @StickRight.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStickRight;
                @StickLeft.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStickLeft;
                @StickLeft.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStickLeft;
                @StickLeft.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStickLeft;
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
                @TriggerLeft.started += instance.OnTriggerLeft;
                @TriggerLeft.performed += instance.OnTriggerLeft;
                @TriggerLeft.canceled += instance.OnTriggerLeft;
                @TriggerRight.started += instance.OnTriggerRight;
                @TriggerRight.performed += instance.OnTriggerRight;
                @TriggerRight.canceled += instance.OnTriggerRight;
                @StickRight.started += instance.OnStickRight;
                @StickRight.performed += instance.OnStickRight;
                @StickRight.canceled += instance.OnStickRight;
                @StickLeft.started += instance.OnStickLeft;
                @StickLeft.performed += instance.OnStickLeft;
                @StickLeft.canceled += instance.OnStickLeft;
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

    // MainMenu
    private readonly InputActionMap m_MainMenu;
    private IMainMenuActions m_MainMenuActionsCallbackInterface;
    private readonly InputAction m_MainMenu_AnyKey;
    private readonly InputAction m_MainMenu_Interact;
    private readonly InputAction m_MainMenu_StickLeft;
    private readonly InputAction m_MainMenu_Back;
    public struct MainMenuActions
    {
        private @PlayerControls m_Wrapper;
        public MainMenuActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @AnyKey => m_Wrapper.m_MainMenu_AnyKey;
        public InputAction @Interact => m_Wrapper.m_MainMenu_Interact;
        public InputAction @StickLeft => m_Wrapper.m_MainMenu_StickLeft;
        public InputAction @Back => m_Wrapper.m_MainMenu_Back;
        public InputActionMap Get() { return m_Wrapper.m_MainMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainMenuActions set) { return set.Get(); }
        public void SetCallbacks(IMainMenuActions instance)
        {
            if (m_Wrapper.m_MainMenuActionsCallbackInterface != null)
            {
                @AnyKey.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnAnyKey;
                @AnyKey.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnAnyKey;
                @AnyKey.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnAnyKey;
                @Interact.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnInteract;
                @StickLeft.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnStickLeft;
                @StickLeft.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnStickLeft;
                @StickLeft.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnStickLeft;
                @Back.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnBack;
            }
            m_Wrapper.m_MainMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @AnyKey.started += instance.OnAnyKey;
                @AnyKey.performed += instance.OnAnyKey;
                @AnyKey.canceled += instance.OnAnyKey;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @StickLeft.started += instance.OnStickLeft;
                @StickLeft.performed += instance.OnStickLeft;
                @StickLeft.canceled += instance.OnStickLeft;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
            }
        }
    }
    public MainMenuActions @MainMenu => new MainMenuActions(this);
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnTriggerLeft(InputAction.CallbackContext context);
        void OnTriggerRight(InputAction.CallbackContext context);
        void OnStickRight(InputAction.CallbackContext context);
        void OnStickLeft(InputAction.CallbackContext context);
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
    public interface IMainMenuActions
    {
        void OnAnyKey(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnStickLeft(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
    }
}
