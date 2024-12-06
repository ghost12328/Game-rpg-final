using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;               // Reference to the player's transform
    public Vector3 offset = new Vector3(0, 5, -10); // Initial offset from the player
    public float followSpeed = 5f;         // How quickly the camera follows the player

    void LateUpdate()
    {
        if (player == null)
        {
            Debug.LogWarning("Player not assigned in CameraFollow script!");
            return;
        }

        // Rotate the offset to match the player's orientation
        Vector3 rotatedOffset = player.rotation * offset;

        // Calculate the target position based on the rotated offset
        Vector3 targetPosition = player.position + rotatedOffset;

        // Smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Keep the camera looking at the player
        transform.LookAt(player);
    }
}
