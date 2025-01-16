using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float driveSpeed = 1.0f; // How fast the car moves
    [SerializeField] private AudioClip engineSound;   // The car engine sound clip
    private AudioSource audioSource;
    private bool isDriving = false;

    private Rigidbody2D rb;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component
        rb.gravityScale = 0;  // Disable gravity
    }

    private void Update()
    {
        if (isDriving)
        {
            transform.Translate(Vector2.right * driveSpeed * Time.deltaTime);

            // Disable gravity and constrain the Rigidbody2D on the Y axis to prevent falling
            if (rb != null)
            {
                rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;  // Freeze Y position and rotation
            }
        }
    }

    public void StartDriving()
    {
        if(!isDriving)
        {
            isDriving = true;
            PlayEngineSound();
        }
    }

    void PlayEngineSound()
    {
        if (audioSource != null && engineSound != null)
        {
            audioSource.clip = engineSound;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void StopDriving()
    {
        if(isDriving)
        {
            isDriving = false;
            audioSource.Stop();
        }
    }
}
