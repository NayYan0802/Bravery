// GENERATED AUTOMATICALLY FROM 'Assets/Character/PlayerInput1.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput1 : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput1()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput1"",
    ""maps"": [
        {
            ""name"": ""CharacterControls"",
            ""id"": ""d56f167e-8997-4b3e-9294-41d3534c0420"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""7152d2e0-c715-42b5-b492-2a7760826c14"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShootDirection"",
                    ""type"": ""Value"",
                    ""id"": ""10c4cbd0-633f-4af9-a4fa-a1f30564a7ee"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""0c72e84a-bf09-4f07-88c6-36a25dde5c09"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeSkin"",
                    ""type"": ""Button"",
                    ""id"": ""46358381-0e70-40ef-94fc-2417eccc46ca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""b897f921-921d-4d87-b33e-8b65f6384e19"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack1"",
                    ""type"": ""Button"",
                    ""id"": ""c9a1e698-93fa-404a-b41a-5f7870f521ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Middle"",
                    ""type"": ""Button"",
                    ""id"": ""12903894-50fe-4be1-93f3-cfb05d726101"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Heavy"",
                    ""type"": ""Button"",
                    ""id"": ""4af92ae3-aa99-421b-a0de-783d1bbf07ae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Knife"",
                    ""type"": ""Button"",
                    ""id"": ""1cb710fa-7dec-4c9c-8604-27fce57f0756"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0e583591-802c-4b4a-a805-0f4b94c29220"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c400416-fdba-4a6e-8fb9-786e5c280251"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""74106eff-66d9-4b19-a910-2767d3ec141d"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeSkin"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f950b0aa-85d5-41f6-b816-8117a4865e6b"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": ""Tap(pressPoint=0.3)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""82d92371-b19a-4618-b29c-97482095a562"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""ShootDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd59d38e-ef1a-42b3-b620-7798ace83532"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Middle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""136365ac-500e-4f01-a2d8-0ca56c9e7b8f"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Heavy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d7ab14f-e348-4e5d-9efa-7d35b125efef"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Hold(duration=0.75,pressPoint=0.1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6f92b3a0-68bc-4dd1-8694-44af88b0e577"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Knife"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""CharacterControlsKeyboard"",
            ""id"": ""86fc84fe-44c7-4612-94c0-2db80f053237"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""e40e7cf0-4924-4d22-aff8-296b5c6384df"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8141a315-7734-40a0-b98f-e75893541852"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""ae820ef4-6b2b-4e0f-90f3-249ff0f6b235"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""1effc852-7e29-4ab9-aeb5-ff771e88ec98"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""66138370-9107-4b7c-946d-c1352fa6282c"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c614a563-f42f-43ac-829d-4916b805a4b1"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""2c928788-d5ce-4cf6-8ed0-0d0ed7d01d54"",
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
                    ""id"": ""044ce306-0f1c-400f-8474-2cfe415c77f9"",
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
                    ""id"": ""278b758c-a712-45eb-811d-9f60fa26bb5b"",
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
                    ""id"": ""8f34c148-3104-4199-a3ee-9b45987671a2"",
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
                    ""id"": ""83b61d5c-6d8e-494a-9c3d-c919e88f0f6c"",
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
                    ""id"": ""c17e2b0c-fe64-47fd-a89e-1edb5c2cd7b8"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CharacterControls
        m_CharacterControls = asset.FindActionMap("CharacterControls", throwIfNotFound: true);
        m_CharacterControls_Movement = m_CharacterControls.FindAction("Movement", throwIfNotFound: true);
        m_CharacterControls_ShootDirection = m_CharacterControls.FindAction("ShootDirection", throwIfNotFound: true);
        m_CharacterControls_Run = m_CharacterControls.FindAction("Run", throwIfNotFound: true);
        m_CharacterControls_ChangeSkin = m_CharacterControls.FindAction("ChangeSkin", throwIfNotFound: true);
        m_CharacterControls_Attack = m_CharacterControls.FindAction("Attack", throwIfNotFound: true);
        m_CharacterControls_Attack1 = m_CharacterControls.FindAction("Attack1", throwIfNotFound: true);
        m_CharacterControls_Middle = m_CharacterControls.FindAction("Middle", throwIfNotFound: true);
        m_CharacterControls_Heavy = m_CharacterControls.FindAction("Heavy", throwIfNotFound: true);
        m_CharacterControls_Knife = m_CharacterControls.FindAction("Knife", throwIfNotFound: true);
        // CharacterControlsKeyboard
        m_CharacterControlsKeyboard = asset.FindActionMap("CharacterControlsKeyboard", throwIfNotFound: true);
        m_CharacterControlsKeyboard_Movement = m_CharacterControlsKeyboard.FindAction("Movement", throwIfNotFound: true);
        m_CharacterControlsKeyboard_Run = m_CharacterControlsKeyboard.FindAction("Run", throwIfNotFound: true);
        m_CharacterControlsKeyboard_Jump = m_CharacterControlsKeyboard.FindAction("Jump", throwIfNotFound: true);
        m_CharacterControlsKeyboard_Attack = m_CharacterControlsKeyboard.FindAction("Attack", throwIfNotFound: true);
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

    // CharacterControls
    private readonly InputActionMap m_CharacterControls;
    private ICharacterControlsActions m_CharacterControlsActionsCallbackInterface;
    private readonly InputAction m_CharacterControls_Movement;
    private readonly InputAction m_CharacterControls_ShootDirection;
    private readonly InputAction m_CharacterControls_Run;
    private readonly InputAction m_CharacterControls_ChangeSkin;
    private readonly InputAction m_CharacterControls_Attack;
    private readonly InputAction m_CharacterControls_Attack1;
    private readonly InputAction m_CharacterControls_Middle;
    private readonly InputAction m_CharacterControls_Heavy;
    private readonly InputAction m_CharacterControls_Knife;
    public struct CharacterControlsActions
    {
        private @PlayerInput1 m_Wrapper;
        public CharacterControlsActions(@PlayerInput1 wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_CharacterControls_Movement;
        public InputAction @ShootDirection => m_Wrapper.m_CharacterControls_ShootDirection;
        public InputAction @Run => m_Wrapper.m_CharacterControls_Run;
        public InputAction @ChangeSkin => m_Wrapper.m_CharacterControls_ChangeSkin;
        public InputAction @Attack => m_Wrapper.m_CharacterControls_Attack;
        public InputAction @Attack1 => m_Wrapper.m_CharacterControls_Attack1;
        public InputAction @Middle => m_Wrapper.m_CharacterControls_Middle;
        public InputAction @Heavy => m_Wrapper.m_CharacterControls_Heavy;
        public InputAction @Knife => m_Wrapper.m_CharacterControls_Knife;
        public InputActionMap Get() { return m_Wrapper.m_CharacterControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterControlsActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterControlsActions instance)
        {
            if (m_Wrapper.m_CharacterControlsActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMovement;
                @ShootDirection.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnShootDirection;
                @ShootDirection.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnShootDirection;
                @ShootDirection.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnShootDirection;
                @Run.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnRun;
                @ChangeSkin.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnChangeSkin;
                @ChangeSkin.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnChangeSkin;
                @ChangeSkin.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnChangeSkin;
                @Attack.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAttack;
                @Attack1.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAttack1;
                @Attack1.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAttack1;
                @Attack1.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAttack1;
                @Middle.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMiddle;
                @Middle.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMiddle;
                @Middle.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMiddle;
                @Heavy.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnHeavy;
                @Heavy.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnHeavy;
                @Heavy.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnHeavy;
                @Knife.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnKnife;
                @Knife.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnKnife;
                @Knife.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnKnife;
            }
            m_Wrapper.m_CharacterControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @ShootDirection.started += instance.OnShootDirection;
                @ShootDirection.performed += instance.OnShootDirection;
                @ShootDirection.canceled += instance.OnShootDirection;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @ChangeSkin.started += instance.OnChangeSkin;
                @ChangeSkin.performed += instance.OnChangeSkin;
                @ChangeSkin.canceled += instance.OnChangeSkin;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Attack1.started += instance.OnAttack1;
                @Attack1.performed += instance.OnAttack1;
                @Attack1.canceled += instance.OnAttack1;
                @Middle.started += instance.OnMiddle;
                @Middle.performed += instance.OnMiddle;
                @Middle.canceled += instance.OnMiddle;
                @Heavy.started += instance.OnHeavy;
                @Heavy.performed += instance.OnHeavy;
                @Heavy.canceled += instance.OnHeavy;
                @Knife.started += instance.OnKnife;
                @Knife.performed += instance.OnKnife;
                @Knife.canceled += instance.OnKnife;
            }
        }
    }
    public CharacterControlsActions @CharacterControls => new CharacterControlsActions(this);

    // CharacterControlsKeyboard
    private readonly InputActionMap m_CharacterControlsKeyboard;
    private ICharacterControlsKeyboardActions m_CharacterControlsKeyboardActionsCallbackInterface;
    private readonly InputAction m_CharacterControlsKeyboard_Movement;
    private readonly InputAction m_CharacterControlsKeyboard_Run;
    private readonly InputAction m_CharacterControlsKeyboard_Jump;
    private readonly InputAction m_CharacterControlsKeyboard_Attack;
    public struct CharacterControlsKeyboardActions
    {
        private @PlayerInput1 m_Wrapper;
        public CharacterControlsKeyboardActions(@PlayerInput1 wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_CharacterControlsKeyboard_Movement;
        public InputAction @Run => m_Wrapper.m_CharacterControlsKeyboard_Run;
        public InputAction @Jump => m_Wrapper.m_CharacterControlsKeyboard_Jump;
        public InputAction @Attack => m_Wrapper.m_CharacterControlsKeyboard_Attack;
        public InputActionMap Get() { return m_Wrapper.m_CharacterControlsKeyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterControlsKeyboardActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterControlsKeyboardActions instance)
        {
            if (m_Wrapper.m_CharacterControlsKeyboardActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_CharacterControlsKeyboardActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_CharacterControlsKeyboardActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_CharacterControlsKeyboardActionsCallbackInterface.OnMovement;
                @Run.started -= m_Wrapper.m_CharacterControlsKeyboardActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_CharacterControlsKeyboardActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_CharacterControlsKeyboardActionsCallbackInterface.OnRun;
                @Jump.started -= m_Wrapper.m_CharacterControlsKeyboardActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_CharacterControlsKeyboardActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_CharacterControlsKeyboardActionsCallbackInterface.OnJump;
                @Attack.started -= m_Wrapper.m_CharacterControlsKeyboardActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_CharacterControlsKeyboardActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_CharacterControlsKeyboardActionsCallbackInterface.OnAttack;
            }
            m_Wrapper.m_CharacterControlsKeyboardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
            }
        }
    }
    public CharacterControlsKeyboardActions @CharacterControlsKeyboard => new CharacterControlsKeyboardActions(this);
    public interface ICharacterControlsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnShootDirection(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnChangeSkin(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnAttack1(InputAction.CallbackContext context);
        void OnMiddle(InputAction.CallbackContext context);
        void OnHeavy(InputAction.CallbackContext context);
        void OnKnife(InputAction.CallbackContext context);
    }
    public interface ICharacterControlsKeyboardActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
    }
}
