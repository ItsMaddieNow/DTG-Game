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
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Jump Release"",
                    ""type"": ""Button"",
                    ""id"": ""145c0b66-986c-448d-a7c0-13608282c698"",
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
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""b293db4d-7347-4e86-a17f-6fbfefaa6ea5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Quick Save"",
                    ""type"": ""Value"",
                    ""id"": ""08927aa9-9d57-4b16-bf6d-335c590fed60"",
                    ""expectedControlType"": ""Axis"",
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
                    ""id"": ""1a7e1eb0-8df9-4269-9144-cd2dba4ab72b"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""f9708316-276a-4341-a502-a29d76c29a57"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b01441b6-7093-4b45-a42a-48ea91ef6454"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""1ec051d7-4026-4931-a097-56f99ccb083f"",
                    ""path"": ""1DAxis(minValue=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quick Save"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""799eecd7-a691-4190-8812-adbbfe649422"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quick Save"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""992da1b1-31b4-41b6-bce8-8e90a75f235f"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quick Save"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f8ef7f2b-57ec-4509-8ee6-0cdb3e65abf1"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump Release"",
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
        m_Gameplay_JumpRelease = m_Gameplay.FindAction("Jump Release", throwIfNotFound: true);
        m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
        m_Gameplay_GrappleButton = m_Gameplay.FindAction("Grapple Button", throwIfNotFound: true);
        m_Gameplay_GrappleToggle = m_Gameplay.FindAction("Grapple Toggle", throwIfNotFound: true);
        m_Gameplay_GrappleDirection = m_Gameplay.FindAction("Grapple Direction", throwIfNotFound: true);
        m_Gameplay_GrappleDistanceControl = m_Gameplay.FindAction("Grapple Distance Control", throwIfNotFound: true);
        m_Gameplay_TorchEnable = m_Gameplay.FindAction("Torch Enable", throwIfNotFound: true);
        m_Gameplay_TorchThrow = m_Gameplay.FindAction("Torch Throw", throwIfNotFound: true);
        m_Gameplay_Pause = m_Gameplay.FindAction("Pause", throwIfNotFound: true);
        m_Gameplay_QuickSave = m_Gameplay.FindAction("Quick Save", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_JumpRelease;
    private readonly InputAction m_Gameplay_Movement;
    private readonly InputAction m_Gameplay_GrappleButton;
    private readonly InputAction m_Gameplay_GrappleToggle;
    private readonly InputAction m_Gameplay_GrappleDirection;
    private readonly InputAction m_Gameplay_GrappleDistanceControl;
    private readonly InputAction m_Gameplay_TorchEnable;
    private readonly InputAction m_Gameplay_TorchThrow;
    private readonly InputAction m_Gameplay_Pause;
    private readonly InputAction m_Gameplay_QuickSave;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @JumpRelease => m_Wrapper.m_Gameplay_JumpRelease;
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputAction @GrappleButton => m_Wrapper.m_Gameplay_GrappleButton;
        public InputAction @GrappleToggle => m_Wrapper.m_Gameplay_GrappleToggle;
        public InputAction @GrappleDirection => m_Wrapper.m_Gameplay_GrappleDirection;
        public InputAction @GrappleDistanceControl => m_Wrapper.m_Gameplay_GrappleDistanceControl;
        public InputAction @TorchEnable => m_Wrapper.m_Gameplay_TorchEnable;
        public InputAction @TorchThrow => m_Wrapper.m_Gameplay_TorchThrow;
        public InputAction @Pause => m_Wrapper.m_Gameplay_Pause;
        public InputAction @QuickSave => m_Wrapper.m_Gameplay_QuickSave;
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
                @JumpRelease.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJumpRelease;
                @JumpRelease.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJumpRelease;
                @JumpRelease.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJumpRelease;
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
                @Pause.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @QuickSave.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnQuickSave;
                @QuickSave.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnQuickSave;
                @QuickSave.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnQuickSave;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @JumpRelease.started += instance.OnJumpRelease;
                @JumpRelease.performed += instance.OnJumpRelease;
                @JumpRelease.canceled += instance.OnJumpRelease;
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
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @QuickSave.started += instance.OnQuickSave;
                @QuickSave.performed += instance.OnQuickSave;
                @QuickSave.canceled += instance.OnQuickSave;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnJumpRelease(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnGrappleButton(InputAction.CallbackContext context);
        void OnGrappleToggle(InputAction.CallbackContext context);
        void OnGrappleDirection(InputAction.CallbackContext context);
        void OnGrappleDistanceControl(InputAction.CallbackContext context);
        void OnTorchEnable(InputAction.CallbackContext context);
        void OnTorchThrow(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnQuickSave(InputAction.CallbackContext context);
    }
}
