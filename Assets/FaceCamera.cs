using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    public GameObject targetCamera; // Assign your main camera here in the Inspector
    public GameObject Locator;

    void LateUpdate()
    {
        if (targetCamera == Locator)
        {
            if (GameObject.FindGameObjectWithTag("MainCamera") != null)
            {
                targetCamera = GameObject.FindGameObjectWithTag("MainCamera");
            }
        }
        if (targetCamera != Locator)
        {
            transform.rotation = targetCamera.transform.rotation;
        }
        

        // // Get the direction from the object to the camera, ignoring the Y-axis difference for rotation
        // Vector3 directionToCamera = targetCamera.transform.position - transform.position;
        // directionToCamera.y = 0; // Flatten the vector to the XZ plane

        // // If the direction is not zero, calculate the rotation
        // if (directionToCamera != Vector3.zero)
        // {
        //     // Calculate the target rotation to look at the camera on the Y-axis
        //     Quaternion targetRotation = Quaternion.LookRotation(directionToCamera);

        //     // Apply only the Y-axis rotation from the targetRotation
        //     // Keep the current X and Z rotations of the object
        //     transform.rotation = Quaternion.Euler(
        //         transform.rotation.eulerAngles.x,
        //         targetRotation.eulerAngles.y,
        //         transform.rotation.eulerAngles.z
        //     );
        // }
    }
}