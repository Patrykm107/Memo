// GENERATED AUTOMATICALLY FROM 'Assets/Input/MemoControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MemoControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MemoControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MemoControls"",
    ""maps"": [
        {
            ""name"": ""During game"",
            ""id"": ""0c65576c-21f5-4ffa-a5d7-75bfd41320fc"",
            ""actions"": [
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""3b87c646-7da2-475b-87c4-ddd803094f28"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""37bab1a6-bf59-4aba-ba63-38a49fad6063"",
                    ""path"": ""<Keyboard>/#(R)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c93574ef-db47-42d8-a06b-50eee844b15f"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // During game
        m_Duringgame = asset.FindActionMap("During game", throwIfNotFound: true);
        m_Duringgame_Exit = m_Duringgame.FindAction("Exit", throwIfNotFound: true);
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

    // During game
    private readonly InputActionMap m_Duringgame;
    private IDuringgameActions m_DuringgameActionsCallbackInterface;
    private readonly InputAction m_Duringgame_Exit;
    public struct DuringgameActions
    {
        private @MemoControls m_Wrapper;
        public DuringgameActions(@MemoControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Exit => m_Wrapper.m_Duringgame_Exit;
        public InputActionMap Get() { return m_Wrapper.m_Duringgame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DuringgameActions set) { return set.Get(); }
        public void SetCallbacks(IDuringgameActions instance)
        {
            if (m_Wrapper.m_DuringgameActionsCallbackInterface != null)
            {
                @Exit.started -= m_Wrapper.m_DuringgameActionsCallbackInterface.OnExit;
                @Exit.performed -= m_Wrapper.m_DuringgameActionsCallbackInterface.OnExit;
                @Exit.canceled -= m_Wrapper.m_DuringgameActionsCallbackInterface.OnExit;
            }
            m_Wrapper.m_DuringgameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Exit.started += instance.OnExit;
                @Exit.performed += instance.OnExit;
                @Exit.canceled += instance.OnExit;
            }
        }
    }
    public DuringgameActions @Duringgame => new DuringgameActions(this);
    public interface IDuringgameActions
    {
        void OnExit(InputAction.CallbackContext context);
    }
}
