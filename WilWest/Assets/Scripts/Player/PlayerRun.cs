using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    [SerializeField] private float _runSpeed;

    private IInputService _inputService;

    public bool IsRunning { get; private set; }

    public float RunSpeed => _runSpeed;


    private void Update()
    {
        IsRunning = _inputService.RunPressed;
    }

    public void Initialize(IInputService inputService)
    {
        _inputService = inputService;
    }
}