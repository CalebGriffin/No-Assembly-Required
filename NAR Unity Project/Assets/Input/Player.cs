// GENERATED AUTOMATICALLY FROM 'Assets/Input/Player.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Player : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player"",
    ""maps"": [
        {
            ""name"": ""PlayerMovement"",
            ""id"": ""a3f3b664-771a-4ee7-9b85-318a26015286"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""e69e8186-0e8d-4a67-aa60-f43e5fa71709"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pickup"",
                    ""type"": ""Button"",
                    ""id"": ""e90f28fb-0832-4bd9-a422-83dbad42d1b3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UseMachine"",
                    ""type"": ""Button"",
                    ""id"": ""576427b2-0a96-4fcf-8105-ff221c52ed82"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""21296be2-aa3c-47fc-aa44-5f5b4f18bcdf"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4c6d8192-d543-4be2-9043-728a3dbddd94"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5f2f2e85-aaf9-4dea-8cd2-60bc839b6c67"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9a6e6cb5-c580-4c1a-b28e-ddf3f38c202d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4bc71e1e-1a07-4ad1-be3c-c4987c4831fa"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2af103bb-0d25-4659-87af-1a0b1c084e39"",
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
                    ""id"": ""33ccaf62-05d8-45c7-955f-9f401e7edafc"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pickup"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0163c42-b434-4f60-b99a-07548bf6909a"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pickup"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a34daf74-6b6a-4f37-b163-8d1216bbba4e"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseMachine"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""461ba867-2501-4d71-9d1c-4ccc3d63ba76"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseMachine"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
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
        // PlayerMovement
        m_PlayerMovement = asset.FindActionMap("PlayerMovement", throwIfNotFound: true);
        m_PlayerMovement_Move = m_PlayerMovement.FindAction("Move", throwIfNotFound: true);
        m_PlayerMovement_Pickup = m_PlayerMovement.FindAction("Pickup", throwIfNotFound: true);
        m_PlayerMovement_UseMachine = m_PlayerMovement.FindAction("UseMachine", throwIfNotFound: true);
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

    // PlayerMovement
    private readonly InputActionMap m_PlayerMovement;
    private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
    private readonly InputAction m_PlayerMovement_Move;
    private readonly InputAction m_PlayerMovement_Pickup;
    private readonly InputAction m_PlayerMovement_UseMachine;
    public struct PlayerMovementActions
    {
        private @Player m_Wrapper;
        public PlayerMovementActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerMovement_Move;
        public InputAction @Pickup => m_Wrapper.m_PlayerMovement_Pickup;
        public InputAction @UseMachine => m_Wrapper.m_PlayerMovement_UseMachine;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMove;
                @Pickup.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPickup;
                @Pickup.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPickup;
                @Pickup.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPickup;
                @UseMachine.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnUseMachine;
                @UseMachine.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnUseMachine;
                @UseMachine.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnUseMachine;
            }
            m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Pickup.started += instance.OnPickup;
                @Pickup.performed += instance.OnPickup;
                @Pickup.canceled += instance.OnPickup;
                @UseMachine.started += instance.OnUseMachine;
                @UseMachine.performed += instance.OnUseMachine;
                @UseMachine.canceled += instance.OnUseMachine;
            }
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IPlayerMovementActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnPickup(InputAction.CallbackContext context);
        void OnUseMachine(InputAction.CallbackContext context);
    }
}
