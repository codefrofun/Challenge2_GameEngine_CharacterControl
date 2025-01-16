using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] public float carDrive = 1.5f;
    [SerializeField] private AudioClip engineSound;
    private AudioSource audioSource;
    public Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Ability to jump
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
        // Stop the car's movement by setting its velocity to zero
        rb.velocity = Vector2.zero;

        // Stop the engine sound when the car stops
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();  // Stop playing the engine sound
        }

        Debug.Log("Car stopped!");
    }

    void OnEnable()
    {
        // Subscribe to the MoveCar event
        InputManager.MoveCar += DriveCar;
    }

    void OnDisable()
    {
        // Unsubscribe from the MoveCar event
        InputManager.MoveCar -= DriveCar;
    }
}