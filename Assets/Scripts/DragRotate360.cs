using UnityEngine;

public class DragRotate360 : MonoBehaviour
{
    public float rotationSpeed = 10.0f;
    //public float minRotation = -25f;
    //public float maxRotation = 25f;

    public float currentRotationx;
    public float currentRotationy;

    void Update()
    {
        if (Input.GetMouseButton(0)) // Check for left mouse button click
        {
            float mouseX = Input.GetAxis("Mouse X"); // Get horizontal mouse movement
            currentRotationx += mouseX * rotationSpeed; // Accumulate rotation based on mouse movement

            float mouseY = Input.GetAxis("Mouse Y");
            currentRotationy += mouseY * rotationSpeed;

            // Clamp the rotation to the defined limits
            //currentRotation = Mathf.Clamp(currentRotation, minRotation, maxRotation);

            // Apply the rotation to the turntable object
            transform.rotation = Quaternion.Euler(0, currentRotationx, currentRotationy); // Rotate around Y-axis
        }
    }
}
