using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelEvent : MonoBehaviour
{
    public Renderer targetRenderer;
    public bool buttonPressed;

    public void ChangeColorGreen()
    {
        if (!buttonPressed)
        {
            //renders new material
            targetRenderer.material.color = Color.green;
            buttonPressed = true; // Mark button as pressed
        }
    }

    public void ChangeColourRed()
    {
        if (buttonPressed)
        {
            //renders new material
            targetRenderer.material.color = Color.red;
            buttonPressed = false;  // Mark button as released
        }
    }
}
