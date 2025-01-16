using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.0f;
    public CharacterController characterController;
    public Vector2 moveDirection = Vector2.zero;


    private void Awake()
    {
        characterController = this.GetComponent<CharacterController>();

        InputActions.MovePlayerEvent += UpdateMoveVector;
    }

    private void UpdateMoveVector(Vector2 InputVector)
    {
        moveDirection = InputVector;
    }

    private void Update()
    {
        HandlePlayerMovement(moveDirection);
    }

    void HandlePlayerMovement(Vector2 moveDirection)
    {
        characterController.Move(moveDirection * Time.deltaTime);
    }

    void OnEnable()
    {
        // Subscribe to the action
        InputActions.MovePlayerEvent += HandlePlayerMovement;
    }

    void OnDisable()
    {
        InputActions.MovePlayerEvent -= UpdateMoveVector;
        InputActions.MovePlayerEvent -= HandlePlayerMovement;
    }
}