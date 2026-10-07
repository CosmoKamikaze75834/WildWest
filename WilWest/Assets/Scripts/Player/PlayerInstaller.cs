using UnityEngine;

public class PlayerInstaller : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private InputService _inputService;
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private PlayerCamera _playerCamera;
    [SerializeField] private PlayerRun _playerRun;
 
    private void Awake()
    {
        _playerMovement.Initialize(_inputService, _playerCamera, _playerRun);
        _playerAnimation.Initialize(_inputService, _playerRun);
        _playerCamera.Initialize(_inputService);
        _playerRun.Initialize(_inputService);
    }
}
