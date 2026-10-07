using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private const string SpeedParameter = "Speed";
    private const float WalkBlendValue = 0.5f;
    private const float RunBlendValue = 1f;

    [SerializeField] private Animator _animator;

    private IInputService _inputService;
    private PlayerRun _playerRun;

    public void Initialize(IInputService inputService, PlayerRun playerRun)
    {
        _inputService = inputService;
        _playerRun = playerRun;
    }

    private void Update()
    {
        bool isMoving = _inputService.MoveDirection.sqrMagnitude > 0f;
        float speed = !isMoving ? 0f : _playerRun.IsRunning ? RunBlendValue : WalkBlendValue;

        _animator.SetFloat(SpeedParameter, speed);
    }
}
