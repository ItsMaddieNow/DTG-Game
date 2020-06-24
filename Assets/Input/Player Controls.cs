// GENERATED AUTOMATICALLY FROM 'Assets/Input/Player Controls.inputactions'

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
    ""name"": ""Player Controls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""9c34e982-2ac0-44c7-a2a1-a35f61cc4d39"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""86fde03a-38cb-4d4f-9adb-e40c132fd544"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""e266d7a7-4aac-4e0f-8643-4f67c0323c3f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grapple Button"",
                    ""type"": ""Button"",
                    ""id"": ""65ebe67a-f09c-4f78-bdf9-f5a99f008588"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grapple Toggle"",
                    ""type"": ""Button"",
                    ""id"": ""0f9d2dcb-23c1-4f71-a95f-11fc150eed25"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grapple Direction"",
                    ""type"": ""Value"",
                    ""id"": ""18bf0829-06f2-4081-8003-c1292e02f806"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grapple Distance Control"",
                    ""type"": ""Value"",
                    ""id"": ""96243144-c140-4cbe-b3ca-2264e3210fca"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Torch Enable"",
                    ""type"": ""Button"",
                    ""id"": ""cfd7b738-5c1c-4791-b39c-d8e46d422b2e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Torch Throw"",
                    ""type"": ""Button"",
                    ""id"": ""7a62adf4-996a-496c-a5be-7b6bed60629c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6c855f0e-427e-4bff-8d67-0a3686c29994"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""934bd922-04af-4aad-a5cf-ca8150058c98"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""52664997-8943-4f92-9b42-cd54662cdd0c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3b00364e-a52a-4d93-8690-e42553464bf4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6e056489-bda0-4c23-839d-f86d263807de"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""475039d4-cd0a-4bbb-8bd1-a94c65ff83c4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a7c7a41f-1052-4d46-aed3-65887b34203e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""48955f86-2b5b-44ea-af42-ab25c368e738"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grapple Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""67d1d579-a496-4ea2-b2f0-46c447878de2"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grapple Toggle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e39cb7ef-1db4-477d-9f1b-96019e71cb6d"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grapple Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""551a08ae-2196-47be-ad6f-cf7dc3c80074"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grapple Distance Control"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6cdc70e9-4a68-44a0-a9aa-f647d3ad5cdd"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grapple Distance Control"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""1a7e1eb0-8df9-4269-9144-cd2dba4ab72b"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grapple Distance Control"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""17bf7f07-60fe-4732-837c-17d8411bdc81"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Torch Enable"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6745b3ee-2fc6-4b0c-b94a-e2ebde3e9b38"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Torch Throw"",
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
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
        m_Gameplay_GrappleButton = m_Gameplay.FindAction("Grapple Button", throwIfNotFound: true);
        m_Gameplay_GrappleToggle = m_Gameplay.FindAction("Grapple Toggle", throwIfNotFound: true);
        m_Gameplay_GrappleDirection = m_Gameplay.FindAction("Grapple Direction", throwIfNotFound: true);
        m_Gameplay_GrappleDistanceControl = m_Gameplay.FindAction("Grapple Distance Control", throwIfNotFound: true);
        m_Gameplay_TorchEnable = m_Gameplay.FindAction("Torch Enable", throwIfNotFound: true);
        m_Gameplay_TorchThrow = m_Gameplay.FindAction("Torch Throw", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_Movement;
    private readonly InputAction m_Gameplay_GrappleButton;
    private readonly InputAction m_Gameplay_GrappleToggle;
    private readonly InputAction m_Gameplay_GrappleDirection;
    private readonly InputAction m_Gameplay_GrappleDistanceControl;
    private readonly InputAction m_Gameplay_TorchEnable;
    private readonly InputAction m_Gameplay_TorchThrow;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputAction @GrappleButton => m_Wrapper.m_Gameplay_GrappleButton;
        public InputAction @GrappleToggle => m_Wrapper.m_Gameplay_GrappleToggle;
        public InputAction @GrappleDirection => m_Wrapper.m_Gameplay_GrappleDirection;
        public InputAction @GrappleDistanceControl => m_Wrapper.m_Gameplay_GrappleDistanceControl;
        public InputAction @TorchEnable => m_Wrapper.m_Gameplay_TorchEnable;
        public InputAction @TorchThrow => m_Wrapper.m_Gameplay_TorchThrow;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @GrappleButton.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrappleButton;
                @GrappleButton.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrappleButton;
                @GrappleButton.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrappleButton;
                @GrappleToggle.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrappleToggle;
                @GrappleToggle.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrappleToggle;
                @GrappleToggle.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrappleToggle;
                @GrappleDirection.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrappleDirection;
                @GrappleDirection.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrappleDirection;
                @GrappleDirection.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrappleDirection;
                @GrappleDistanceControl.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrappleDistanceControl;
                @GrappleDistanceControl.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrappleDistanceControl;
                @GrappleDistanceControl.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrappleDistanceControl;
                @TorchEnable.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTorchEnable;
                @TorchEnable.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTorchEnable;
                @TorchEnable.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTorchEnable;
                @TorchThrow.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTorchThrow;
                @TorchThrow.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTorchThrow;
                @TorchThrow.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTorchThrow;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @GrappleButton.started += instance.OnGrappleButton;
                @GrappleButton.performed += instance.OnGrappleButton;
                @GrappleButton.canceled += instance.OnGrappleButton;
                @GrappleToggle.started += instance.OnGrappleToggle;
                @GrappleToggle.performed += instance.OnGrappleToggle;
                @GrappleToggle.canceled += instance.OnGrappleToggle;
                @GrappleDirection.started += instance.OnGrappleDirection;
                @GrappleDirection.performed += instance.OnGrappleDirection;
                @GrappleDirection.canceled += instance.OnGrappleDirection;
                @GrappleDistanceControl.started += instance.OnGrappleDistanceControl;
                @GrappleDistanceControl.performed += instance.OnGrappleDistanceControl;
                @GrappleDistanceControl.canceled += instance.OnGrappleDistanceControl;
                @TorchEnable.started += instance.OnTorchEnable;
                @TorchEnable.performed += instance.OnTorchEnable;
                @TorchEnable.canceled += instance.OnTorchEnable;
                @TorchThrow.started += instance.OnTorchThrow;
                @TorchThrow.performed += instance.OnTorchThrow;
                @TorchThrow.canceled += instance.OnTorchThrow;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnGrappleButton(InputAction.CallbackContext context);
        void OnGrappleToggle(InputAction.CallbackContext context);
        void OnGrappleDirection(InputAction.CallbackContext context);
        void OnGrappleDistanceControl(InputAction.CallbackContext context);
        void OnTorchEnable(InputAction.CallbackContext context);
        void OnTorchThrow(InputAction.CallbackContext context);
    }
}
