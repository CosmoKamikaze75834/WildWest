using UnityEngine;

public interface IInputService
{
    public Vector2 MoveDirection { get;}
    public Vector2 LookDirection { get;}
    bool RunPressed { get; }
}