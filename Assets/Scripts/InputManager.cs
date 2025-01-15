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

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        
    }
}

public static class InputActions
{
    public static Action MovePlayerEvent;
}