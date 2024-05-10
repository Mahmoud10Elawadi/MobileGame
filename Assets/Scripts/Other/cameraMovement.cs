using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed;

    void Update()
    {
        // Move the camera vertically along the y-axis
        transform.position += new Vector3(0, cameraSpeed * Time.deltaTime, 0);
    }
}