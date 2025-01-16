using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.0f;
    public CharacterController characterController; // Reference to the CharacterController component for movement control
    public Vector2 moveDirection = Vector2.zero;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Get the CharacterController component attached to the GameObject
        characterController = this.GetComponent<CharacterController>();
        // Subscribe to the MovePlayerEvent to update movement direction
        InputActions.MovePlayerEvent += UpdateMoveVector;
    }

    // Method to update the movement direction based on the input from InputManager
    private void UpdateMoveVector(Vector2 InputVector)
    {
        moveDirection = InputVector;
    }

    private void Update()
    {
        // Handle the player movement using the current direction
        HandlePlayerMovement(moveDirection);
    }

    void HandlePlayerMovement(Vector2 moveDirection)
    {
        // Move the character based on the input direction and moveSpeed
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    // Subscribe to the action when the script is enabled
    void OnEnable()
    {
        // Subscribe to the action
        InputActions.MovePlayerEvent += HandlePlayerMovement;
    }

    void OnDisable()
    {
        // Unsubscribe from the MovePlayerEvent
        InputActions.MovePlayerEvent -= UpdateMoveVector;
        InputActions.MovePlayerEvent -= HandlePlayerMovement;
    }
}