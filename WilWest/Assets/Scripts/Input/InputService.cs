using UnityEngine;
using UnityEngine.InputSystem;

public class InputService : MonoBehaviour, IInputService
{
    private PlayerInputActions _controls;

    public Vector2 MoveDirection { get; private set; }
    public Vector2 LookDirection { get; private set; }

    public bool RunPressed { get; private set; }

    private void Awake()
    {
        _controls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        _controls.Player.Move.Enable();
        _controls.Player.Look.Enable();
        _controls.Player.Run.Enable();

        _controls.Player.Move.performed += OnMove;
        _controls.Player.Move.canceled += OnMove;

        _controls.Player.Look.performed += OnLook;
        _controls.Player.Look.canceled += OnLook;

        _controls.Player.Run.performed += OnRun;
        _controls.Player.Run.canceled += OnRun;
    }


    private void OnDisable()
    {
        _controls.Player.Move.Disable();
        _controls.Player.Look.Disable();
        _controls.Player.Run.Disable();

        _controls.Player.Move.performed -= OnMove;
        _controls.Player.Move.canceled -= OnMove;

        _controls.Player.Look.performed -= OnLook;
        _controls.Player.Look.canceled -= OnLook;

        _controls.Player.Run.performed -= OnRun;
        _controls.Player.Run.canceled -= OnRun;
    }

    private void OnRun(InputAction.CallbackContext context)
    {
        RunPressed = context.ReadValueAsButton();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        MoveDirection = context.ReadValue<Vector2>();
    }

    private void OnLook(InputAction.CallbackContext context)
    {
        LookDirection = context.ReadValue<Vector2>();
    }
}