using UnityEngine;

public class DragRotate : MonoBehaviour
{
    public float rotationSpeed = 10.0f;
    public float minRotation = -25f;
    public float maxRotation = 25f;

    public float currentRotation;

    void Update()
    {
        if (Input.GetMouseButton(0)) // Check for left mouse button click
        {
            float mouseX = Input.GetAxis("Mouse X"); // Get horizontal mouse movement
            currentRotation += mouseX * rotationSpeed; // Accumulate rotation based on mouse movement

            // Clamp the rotation to the defined limits
            currentRotation = Mathf.Clamp(currentRotation, minRotation, maxRotation);

            // Apply the rotation to the turntable object
            transform.rotation = Quaternion.Euler(0, currentRotation, 0); // Rotate around Y-axis
        }
    }
}
