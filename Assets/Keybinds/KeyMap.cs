//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Keybinds/KeyMap.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @KeyMap: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @KeyMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""KeyMap"",
    ""maps"": [
        {
            ""name"": ""PlayerControls"",
            ""id"": ""3d7b77de-dc7f-467e-813c-21e121f105b6"",
            ""actions"": [
                {
                    ""name"": ""Dynamo"",
                    ""type"": ""Value"",
                    ""id"": ""7245b6e2-3d5a-4d36-b5b1-412b21e10e55"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Oxygen"",
                    ""type"": ""Button"",
                    ""id"": ""cca0d182-263c-4f98-836e-e276f213f521"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Oxygen2"",
                    ""type"": ""Button"",
                    ""id"": ""d94160ee-1861-4952-a9d9-8bf17b053205"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Wiper"",
                    ""type"": ""Value"",
                    ""id"": ""32884280-6bdd-4ee7-890e-78e4e632fece"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=1)"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""PhoneCall"",
                    ""type"": ""Button"",
                    ""id"": ""2d1d7e2c-a19b-4623-9b5e-c193a5f34bb6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TrashOverload"",
                    ""type"": ""Button"",
                    ""id"": ""f9246ecd-90c4-4aff-a5b7-a1d5915d6fcd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AlarmClock"",
                    ""type"": ""Button"",
                    ""id"": ""32757295-9270-4dff-996a-6be3cdd21226"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LeftJoystick"",
                    ""type"": ""Value"",
                    ""id"": ""7d2e2fa3-ad8d-4587-ab11-34de36a62f6c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""RightJoystick"",
                    ""type"": ""Value"",
                    ""id"": ""8298a004-c1f3-41dd-b5db-edb4de6c5c60"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""ENG binds"",
                    ""id"": ""5d0b05a0-1820-4eca-bdbd-f63b572cc9b8"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dynamo"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3bcca14e-657b-4f5f-8480-6e6a3b751326"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dynamo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ec71577c-bada-476c-9ae0-6beebfdaffe5"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dynamo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e090e07f-78b4-4e0d-94db-8a0c5bfe3626"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dynamo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""40ea11fe-164b-4157-9abf-41146820c3d6"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dynamo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""78fe7823-dd4e-4e89-98ba-4fd887e9a05e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Wiper"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e7b6e2f2-311d-4599-bf52-958b854fcda3"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Wiper"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9a8fa9d6-3575-449e-9307-0c50aee5533c"",
                    ""path"": ""<Keyboard>/numpad8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PhoneCall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55c0ee11-7d95-4f5b-a447-a61bdded744e"",
                    ""path"": ""<Keyboard>/numpad3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TrashOverload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c136e71-c1e7-4216-94f8-965d690d846e"",
                    ""path"": ""<Keyboard>/numpad4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AlarmClock"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""0c4bb666-a333-43d3-b593-dd095701d4a8"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftJoystick"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c2374b94-4030-43ca-b459-0d6ef8be3ec1"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftJoystick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""04fbdaa5-b224-4731-b564-87b4d4a984a2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftJoystick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""6c861d4a-45f9-4bbb-a8c0-909824c8bdac"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightJoystick"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6cbd7585-c2cd-4e20-8bf0-4ee1b8b9e1af"",
                    ""path"": ""<Keyboard>/7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightJoystick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""76b42ccf-1ecc-436e-bb23-4a045be1044a"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightJoystick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""bb01a479-364d-4609-b6d3-d36cfcf42cda"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Oxygen2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5379d22a-a27f-432e-b11c-780f799b5368"",
                    ""path"": ""<Keyboard>/numpad9"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Oxygen"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""GO"",
            ""id"": ""11512382-816d-43ba-a149-d0692c395e06"",
            ""actions"": [
                {
                    ""name"": ""StarGame"",
                    ""type"": ""Button"",
                    ""id"": ""dc330bc4-a7fd-4c6c-9e3e-cd5fee024e50"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c2f3a27a-32d6-4065-a3d8-f9b78ca8426a"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StarGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerControls
        m_PlayerControls = asset.FindActionMap("PlayerControls", throwIfNotFound: true);
        m_PlayerControls_Dynamo = m_PlayerControls.FindAction("Dynamo", throwIfNotFound: true);
        m_PlayerControls_Oxygen = m_PlayerControls.FindAction("Oxygen", throwIfNotFound: true);
        m_PlayerControls_Oxygen2 = m_PlayerControls.FindAction("Oxygen2", throwIfNotFound: true);
        m_PlayerControls_Wiper = m_PlayerControls.FindAction("Wiper", throwIfNotFound: true);
        m_PlayerControls_PhoneCall = m_PlayerControls.FindAction("PhoneCall", throwIfNotFound: true);
        m_PlayerControls_TrashOverload = m_PlayerControls.FindAction("TrashOverload", throwIfNotFound: true);
        m_PlayerControls_AlarmClock = m_PlayerControls.FindAction("AlarmClock", throwIfNotFound: true);
        m_PlayerControls_LeftJoystick = m_PlayerControls.FindAction("LeftJoystick", throwIfNotFound: true);
        m_PlayerControls_RightJoystick = m_PlayerControls.FindAction("RightJoystick", throwIfNotFound: true);
        // GO
        m_GO = asset.FindActionMap("GO", throwIfNotFound: true);
        m_GO_StarGame = m_GO.FindAction("StarGame", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // PlayerControls
    private readonly InputActionMap m_PlayerControls;
    private List<IPlayerControlsActions> m_PlayerControlsActionsCallbackInterfaces = new List<IPlayerControlsActions>();
    private readonly InputAction m_PlayerControls_Dynamo;
    private readonly InputAction m_PlayerControls_Oxygen;
    private readonly InputAction m_PlayerControls_Oxygen2;
    private readonly InputAction m_PlayerControls_Wiper;
    private readonly InputAction m_PlayerControls_PhoneCall;
    private readonly InputAction m_PlayerControls_TrashOverload;
    private readonly InputAction m_PlayerControls_AlarmClock;
    private readonly InputAction m_PlayerControls_LeftJoystick;
    private readonly InputAction m_PlayerControls_RightJoystick;
    public struct PlayerControlsActions
    {
        private @KeyMap m_Wrapper;
        public PlayerControlsActions(@KeyMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Dynamo => m_Wrapper.m_PlayerControls_Dynamo;
        public InputAction @Oxygen => m_Wrapper.m_PlayerControls_Oxygen;
        public InputAction @Oxygen2 => m_Wrapper.m_PlayerControls_Oxygen2;
        public InputAction @Wiper => m_Wrapper.m_PlayerControls_Wiper;
        public InputAction @PhoneCall => m_Wrapper.m_PlayerControls_PhoneCall;
        public InputAction @TrashOverload => m_Wrapper.m_PlayerControls_TrashOverload;
        public InputAction @AlarmClock => m_Wrapper.m_PlayerControls_AlarmClock;
        public InputAction @LeftJoystick => m_Wrapper.m_PlayerControls_LeftJoystick;
        public InputAction @RightJoystick => m_Wrapper.m_PlayerControls_RightJoystick;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerControlsActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerControlsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerControlsActionsCallbackInterfaces.Add(instance);
            @Dynamo.started += instance.OnDynamo;
            @Dynamo.performed += instance.OnDynamo;
            @Dynamo.canceled += instance.OnDynamo;
            @Oxygen.started += instance.OnOxygen;
            @Oxygen.performed += instance.OnOxygen;
            @Oxygen.canceled += instance.OnOxygen;
            @Oxygen2.started += instance.OnOxygen2;
            @Oxygen2.performed += instance.OnOxygen2;
            @Oxygen2.canceled += instance.OnOxygen2;
            @Wiper.started += instance.OnWiper;
            @Wiper.performed += instance.OnWiper;
            @Wiper.canceled += instance.OnWiper;
            @PhoneCall.started += instance.OnPhoneCall;
            @PhoneCall.performed += instance.OnPhoneCall;
            @PhoneCall.canceled += instance.OnPhoneCall;
            @TrashOverload.started += instance.OnTrashOverload;
            @TrashOverload.performed += instance.OnTrashOverload;
            @TrashOverload.canceled += instance.OnTrashOverload;
            @AlarmClock.started += instance.OnAlarmClock;
            @AlarmClock.performed += instance.OnAlarmClock;
            @AlarmClock.canceled += instance.OnAlarmClock;
            @LeftJoystick.started += instance.OnLeftJoystick;
            @LeftJoystick.performed += instance.OnLeftJoystick;
            @LeftJoystick.canceled += instance.OnLeftJoystick;
            @RightJoystick.started += instance.OnRightJoystick;
            @RightJoystick.performed += instance.OnRightJoystick;
            @RightJoystick.canceled += instance.OnRightJoystick;
        }

        private void UnregisterCallbacks(IPlayerControlsActions instance)
        {
            @Dynamo.started -= instance.OnDynamo;
            @Dynamo.performed -= instance.OnDynamo;
            @Dynamo.canceled -= instance.OnDynamo;
            @Oxygen.started -= instance.OnOxygen;
            @Oxygen.performed -= instance.OnOxygen;
            @Oxygen.canceled -= instance.OnOxygen;
            @Oxygen2.started -= instance.OnOxygen2;
            @Oxygen2.performed -= instance.OnOxygen2;
            @Oxygen2.canceled -= instance.OnOxygen2;
            @Wiper.started -= instance.OnWiper;
            @Wiper.performed -= instance.OnWiper;
            @Wiper.canceled -= instance.OnWiper;
            @PhoneCall.started -= instance.OnPhoneCall;
            @PhoneCall.performed -= instance.OnPhoneCall;
            @PhoneCall.canceled -= instance.OnPhoneCall;
            @TrashOverload.started -= instance.OnTrashOverload;
            @TrashOverload.performed -= instance.OnTrashOverload;
            @TrashOverload.canceled -= instance.OnTrashOverload;
            @AlarmClock.started -= instance.OnAlarmClock;
            @AlarmClock.performed -= instance.OnAlarmClock;
            @AlarmClock.canceled -= instance.OnAlarmClock;
            @LeftJoystick.started -= instance.OnLeftJoystick;
            @LeftJoystick.performed -= instance.OnLeftJoystick;
            @LeftJoystick.canceled -= instance.OnLeftJoystick;
            @RightJoystick.started -= instance.OnRightJoystick;
            @RightJoystick.performed -= instance.OnRightJoystick;
            @RightJoystick.canceled -= instance.OnRightJoystick;
        }

        public void RemoveCallbacks(IPlayerControlsActions instance)
        {
            if (m_Wrapper.m_PlayerControlsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerControlsActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerControlsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerControlsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerControlsActions @PlayerControls => new PlayerControlsActions(this);

    // GO
    private readonly InputActionMap m_GO;
    private List<IGOActions> m_GOActionsCallbackInterfaces = new List<IGOActions>();
    private readonly InputAction m_GO_StarGame;
    public struct GOActions
    {
        private @KeyMap m_Wrapper;
        public GOActions(@KeyMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @StarGame => m_Wrapper.m_GO_StarGame;
        public InputActionMap Get() { return m_Wrapper.m_GO; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GOActions set) { return set.Get(); }
        public void AddCallbacks(IGOActions instance)
        {
            if (instance == null || m_Wrapper.m_GOActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GOActionsCallbackInterfaces.Add(instance);
            @StarGame.started += instance.OnStarGame;
            @StarGame.performed += instance.OnStarGame;
            @StarGame.canceled += instance.OnStarGame;
        }

        private void UnregisterCallbacks(IGOActions instance)
        {
            @StarGame.started -= instance.OnStarGame;
            @StarGame.performed -= instance.OnStarGame;
            @StarGame.canceled -= instance.OnStarGame;
        }

        public void RemoveCallbacks(IGOActions instance)
        {
            if (m_Wrapper.m_GOActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGOActions instance)
        {
            foreach (var item in m_Wrapper.m_GOActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GOActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GOActions @GO => new GOActions(this);
    public interface IPlayerControlsActions
    {
        void OnDynamo(InputAction.CallbackContext context);
        void OnOxygen(InputAction.CallbackContext context);
        void OnOxygen2(InputAction.CallbackContext context);
        void OnWiper(InputAction.CallbackContext context);
        void OnPhoneCall(InputAction.CallbackContext context);
        void OnTrashOverload(InputAction.CallbackContext context);
        void OnAlarmClock(InputAction.CallbackContext context);
        void OnLeftJoystick(InputAction.CallbackContext context);
        void OnRightJoystick(InputAction.CallbackContext context);
    }
    public interface IGOActions
    {
        void OnStarGame(InputAction.CallbackContext context);
    }
}
