using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerAction : MonoBehaviour
{
    [SerializeField] public float carDrive = 0.4f;
    public Rigidbody2D rb;

    void Start()
    {
        // Get the Rigidbody2D component attached to the GameObject
        rb = GetComponent<Rigidbody2D>();
        // Disable gravity and prevent the worker from moving along the Y-axis or rotating
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    void WorkerMove()
    {
        Debug.Log("Worker is running!");  // Ensure the method is called
        // Apply force to the car in the right direction
        Vector2 rightForce = Vector2.right * carDrive;
        rb.AddForce(rightForce, ForceMode2D.Impulse);
    }

    void StopWorker()
    {
        // Stop the worker's movement by setting its velocity to zero
        rb.velocity = Vector2.zero;
        Debug.Log("Worker stopped!");
    }

    void OnEnable()
    {
        // Subscribe to the MoveCar event (for when the spacebar is pressed)
        InputManager.MoveCar += WorkerMove;
        // Subscribe to the StopCar event (for when the spacebar is released)
        InputManager.StopCar += StopWorker;
    }

    void OnDisable()
    {
        // Unsubscribe from the events
        InputManager.MoveCar -= WorkerMove;
        InputManager.StopCar -= StopWorker;
    }
}
