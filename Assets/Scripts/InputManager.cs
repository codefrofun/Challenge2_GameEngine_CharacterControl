using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
using JetBrains.Annotations;

public class InputManager : MonoBehaviour, GameInput.IPlayerActions
{
    public static event System.Action MovePlayerEvent;   // For movement
    public static event System.Action InteractionEvent;  // For space bar

    public GameInput gameInput;
    void Awake()
    {
        gameInput = new GameInput();
        gameInput.Player.Enable();

        gameInput.Player.SetCallbacks(this);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
        {
           // Debug.Log("Move has been activated/pressed" + context.ReadValue<Vector2>());
            InputActions.MovePlayerEvent?.Invoke(context.ReadValue<Vector2>());
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.started || context.performed)
        {
            InteractionEvent?.Invoke();  // Trigger interaction when spacebar is pressed
        }
    }

    void OnDisable()
    {
        gameInput.Player.Disable();
    }

    public void OnCarWorkerSound(InputAction.CallbackContext context)
    {
        //
    }
}

public static class InputActions
{
    public static Action <Vector2> MovePlayerEvent;
}