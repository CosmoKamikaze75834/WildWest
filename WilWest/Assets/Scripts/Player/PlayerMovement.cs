using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private const float AxisY = 0;
    private const float GroundedVerticalVelocity = -2f;

    [Range(1, 20)]
    [SerializeField] private float _speedWalk;

    private PlayerCamera _camera;
    private PlayerRun _playerRun;
    private IInputService _inputService;
    private CharacterController _characterController;

    private float _verticalVelocity;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float currentSpeed = _playerRun.IsRunning? _playerRun.RunSpeed : _speedWalk;

        Vector3 forward = _camera.GetForwardOnGround();
        Vector3 right = _camera.GetRight();

        var playerInput = forward * _inputService.MoveDirection.y + right * _inputService.MoveDirection.x;
        playerInput *= currentSpeed * Time.deltaTime;

        _characterController.Move(playerInput + Vector3.up * CalculateVerticalMovement());
    }

    private float CalculateVerticalMovement()
    {
        if (_characterController.isGrounded && _verticalVelocity < 0f)
            _verticalVelocity = GroundedVerticalVelocity;

        _verticalVelocity += Physics.gravity.y * Time.deltaTime;

        return _verticalVelocity * Time.deltaTime;
    }

    public void Initialize(IInputService inputService, PlayerCamera camera, PlayerRun playerRun)
    {
        _inputService = inputService;
        _camera = camera;
        _playerRun = playerRun;
    }
}
