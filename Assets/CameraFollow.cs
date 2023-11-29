using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;         // The target to follow (the player's Transform)
    //public float smoothSpeed = 0.1f; // The speed at which the camera follows the player
    public Vector3 offset;           // The offset between the camera and the player

    void LateUpdate()
    {
        if (target == null)
        {
            return; // If the target is not set, exit the function
        }

        Vector3 desiredPosition = target.position + offset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

       // transform.position = smoothedPosition;
    }
}
