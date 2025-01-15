using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
using JetBrains.Annotations;

public class InputManager : MonoBehaviour, GameInput.IPlayerActions
{
    public GameInput gameInput;
    void Awake()
    {
        gameInput = new GameInput();
        gameInput.Player.Enable();

        gameInput.Player.SetCallbacks(this);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Move has been activated/pressed" + context.ReadValue<Vector2>());
            InputActions.MovePlayerEvent?.Invoke(context.ReadValue<Vector2>());
        }
    }
}

public static class InputActions
{
    public static Action <Vector2> MovePlayerEvent;
}