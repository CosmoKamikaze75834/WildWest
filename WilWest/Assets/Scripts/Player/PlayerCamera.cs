using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;

    [SerializeField] private float _horizontalTurnSensitivity = 10f;
    [SerializeField] private float _verticalTurnSensitivity = 10f;

    [SerializeField] private float _verticalMinAngle = -89f;
    [SerializeField] private float _verticalMaxAngle = 90f;

    private Transform _playerTransform;
    private IInputService _inputService;

    private float _cameraAngle;

    private void Awake()
    {
        _cameraAngle = _cameraTransform.localEulerAngles.x;
        _playerTransform = transform;
    }

    public void Initialize(IInputService inputService)
    {
        _inputService = inputService;
    }

    public Vector3 GetForwardOnGround() =>
        Vector3.ProjectOnPlane(_cameraTransform.forward, Vector3.up).normalized;

    public Vector3 GetRight() =>
        Vector3.ProjectOnPlane(_cameraTransform.right, Vector3.up).normalized;

    public void RotateCameraVertical()
    {
        _cameraAngle -= _inputService.LookDirection.y * _verticalTurnSensitivity;

        _cameraAngle = Mathf.Clamp(_cameraAngle,_verticalMinAngle, _verticalMaxAngle);

        _cameraTransform.localEulerAngles = Vector3.right * _cameraAngle;
    }

    public void RotateCameraHorizontal()
    {
        _playerTransform.Rotate(Vector3.up *_horizontalTurnSensitivity * _inputService.LookDirection.x);
    }

    private void Update()
    {
        RotateCameraVertical();
        RotateCameraHorizontal();
    }
}