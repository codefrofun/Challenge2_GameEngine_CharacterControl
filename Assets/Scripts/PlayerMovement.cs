using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController characterController;
    public float moveSpeed = 2.0f;

    public Vector2 moveDirection = new Vector2(0.00f, 0.00f);

    private void Start()
    {
        characterController = this.GetComponent<CharacterController>();
    }

    void HandlePlayerMovement()
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
        // Unsubscribe
        InputActions.MovePlayerEvent -= HandlePlayerMovement;
    }
}
