using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
using JetBrains.Annotations;

public class InputManager : MonoBehaviour, GameInput.IPlayerActions
{

    public GameInput gameInput;
    public static Action MoveCar;
    public static event Action StopCar;

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
        Vector2 moveInput = context.ReadValue<Vector2>();
        InputActions.MovePlayerEvent?.Invoke(moveInput);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.started || context.performed)
        {
            InputActions.MoveCar?.Invoke();   // Trigger interaction when spacebar is pressed
        }
    }

    public void OnCarWorkerSound(InputAction.CallbackContext context)
    {
        Debug.Log("Space was pressed!");
        if (context.started)  // Detect when Space is pressed
        {
            MoveCar?.Invoke(); // Trigger the car movement
        }

        if (context.canceled)  // Detect when Space is released
        {
            StopCar?.Invoke(); // Trigger the car stop
        }
    }


    void OnDisable()
    {
        gameInput.Player.Disable();
    }
}

public static class InputActions
{
    public static Action <Vector2> MovePlayerEvent;
    public static Action MoveCar;
}