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
            ""id"": ""77bbaa7a-2057-4a49-8a36-f9f51e119786"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""9a1cd3c4-ae8e-4014-bdc5-4c920824e867"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""67534d79-f612-454e-b13f-8aeb72352419"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grapple Toggle"",
                    ""type"": ""Button"",
                    ""id"": ""e13696d5-45d1-4b88-bdf1-e36fcd9518f1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grapple Direction"",
                    ""type"": ""Value"",
                    ""id"": ""5512c846-1c93-40c0-afc3-35c79ccce737"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grapple Button"",
                    ""type"": ""Button"",
                    ""id"": ""4aeab89e-6d6d-4de4-9c9f-e90800ed0839"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grapple Distance Control"",
                    ""type"": ""Value"",
                    ""id"": ""12dac22c-22d1-4efe-84b7-bfc1da3b2ab8"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Torch Enable"",
                    ""type"": ""Button"",
                    ""id"": ""fd13c51a-6338-4c38-922d-615c9a44085d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Torch Throw"",
                    ""type"": ""Button"",
                    ""id"": ""5c7f40a2-f247-49c0-b305-ca1d88faea07"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c3d37bdd-988c-4f43-add3-ccbaf7422975"",
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
                    ""id"": ""bebf72bc-0aaf-4492-ac68-169453afbc86"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""db650822-c913-4ee0-8de4-295406ab88ca"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD [Keyboard]"",
                    ""id"": ""2a9e7310-d5cd-45fb-bf9e-37b246a0607a"",
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
                    ""id"": ""a191d131-3190-4bdf-9a6a-bd491a6ab0fd"",
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
                    ""id"": ""d441823d-5ab0-44cb-b18d-893bd3792d6a"",
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
                    ""id"": ""3d751e53-71b7-45e3-81bd-71b8a74f194d"",
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
                    ""id"": ""8782170e-2a0c-4d65-adea-b7176836c3b2"",
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
                    ""id"": ""35251fee-e60a-4c7f-b6d4-b49824f2cc7f"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grapple Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""83a4a55c-3d89-492a-9b84-3db89704e080"",
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
                    ""id"": ""97b1f92f-eded-4543-8191-5056cec04fbf"",
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
                    ""id"": ""1fe3aa2a-b4de-4af1-9df3-e87a4b3d249a"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=2)"",
                    ""groups"": """",
                    ""action"": ""Grapple Distance Control"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""4a243779-cdde-48a0-bbe6-05143eded11b"",
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
                    ""id"": ""fc23bd65-6fba-4522-9717-05d1a0349293"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grapple Distance Control"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""dfede36e-833b-49d5-b362-dc97b7ec9e92"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grapple Distance Control"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""dc711fae-ca0f-4295-ad65-5ac2229d50f8"",
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
                    ""id"": ""5ad37b64-471d-48dd-bd68-5b6c1da2637e"",
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
        m_Gameplay_GrappleToggle = m_Gameplay.FindAction("Grapple Toggle", throwIfNotFound: true);
        m_Gameplay_GrappleDirection = m_Gameplay.FindAction("Grapple Direction", throwIfNotFound: true);
        m_Gameplay_GrappleButton = m_Gameplay.FindAction("Grapple Button", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_GrappleToggle;
    private readonly InputAction m_Gameplay_GrappleDirection;
    private readonly InputAction m_Gameplay_GrappleButton;
    private readonly InputAction m_Gameplay_GrappleDistanceControl;
    private readonly InputAction m_Gameplay_TorchEnable;
    private readonly InputAction m_Gameplay_TorchThrow;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputAction @GrappleToggle => m_Wrapper.m_Gameplay_GrappleToggle;
        public InputAction @GrappleDirection => m_Wrapper.m_Gameplay_GrappleDirection;
        public InputAction @GrappleButton => m_Wrapper.m_Gameplay_GrappleButton;
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
                @GrappleToggle.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrappleToggle;
                @GrappleToggle.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrappleToggle;
                @GrappleToggle.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrappleToggle;
                @GrappleDirection.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrappleDirection;
                @GrappleDirection.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrappleDirection;
                @GrappleDirection.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrappleDirection;
                @GrappleButton.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrappleButton;
                @GrappleButton.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrappleButton;
                @GrappleButton.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrappleButton;
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
                @GrappleToggle.started += instance.OnGrappleToggle;
                @GrappleToggle.performed += instance.OnGrappleToggle;
                @GrappleToggle.canceled += instance.OnGrappleToggle;
                @GrappleDirection.started += instance.OnGrappleDirection;
                @GrappleDirection.performed += instance.OnGrappleDirection;
                @GrappleDirection.canceled += instance.OnGrappleDirection;
                @GrappleButton.started += instance.OnGrappleButton;
                @GrappleButton.performed += instance.OnGrappleButton;
                @GrappleButton.canceled += instance.OnGrappleButton;
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
        void OnGrappleToggle(InputAction.CallbackContext context);
        void OnGrappleDirection(InputAction.CallbackContext context);
        void OnGrappleButton(InputAction.CallbackContext context);
        void OnGrappleDistanceControl(InputAction.CallbackContext context);
        void OnTorchEnable(InputAction.CallbackContext context);
        void OnTorchThrow(InputAction.CallbackContext context);
    }
}
