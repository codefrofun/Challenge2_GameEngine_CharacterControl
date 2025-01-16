using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] public float carDrive = 1.5f;
    [SerializeField] private AudioClip engineSound; // Audio clip to play the engine sound
    private AudioSource audioSource;
    // Reference to the Rigidbody2D component for physics-based movement
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Disable gravity and prevent the car from moving along the Y-axis or rotating
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

        audioSource = GetComponent<AudioSource>();  // Get the AudioSource component

        // Ensure the audio source is set up for looping the engine sound
        if (audioSource != null && engineSound != null)
        {
            audioSource.clip = engineSound;
            audioSource.loop = true;  // Loop the engine sound when it's playing
        }
    }

    /// <summary>
    /// Method to drive the car by applying force in the right direction
    /// </summary>
    void DriveCar()
    {
        Debug.Log("Car is driving!");  // Ensure the method is called
        // Apply force to the car in the right direction
        Vector2 rightForce = Vector2.right * carDrive;
        rb.AddForce(rightForce, ForceMode2D.Impulse);  // Impulse force to simulate immediate movement

        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();  // Start playing the engine sound
        }
    }

    void StopCar()
    {
        Debug.Log("Car stopped!");

        // Stop the car's movement by setting its velocity to zero
        rb.velocity = Vector2.zero;

        // Stop the engine sound
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();  // Stop the engine sound if it's playing
        }
    }

    void OnEnable()
    {
        // Subscribe to the MoveCar and StopCar events
        InputManager.MoveCar += DriveCar;
        InputManager.StopCar += StopCar;
    }

    void OnDisable()
    {
        // Unsubscribe from the MoveCar and StopCar events
        InputManager.MoveCar -= DriveCar;
        InputManager.StopCar -= StopCar;
    }
}