using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;  // Reference to the player's Rigidbody
    public float moveSpeed = 5f;
    public Transform cameraTransform;  // Reference to the camera's transform
    public float rotationSpeed = 10f;  // Speed at which the player rotates

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Get the Rigidbody component

        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;  // Automatically find the main camera if not assigned
        }
    }

    void Update()
    {
        if (rb != null && !rb.isKinematic)
        {
            // Get player input (WASD or arrow keys)
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            // Get the camera's forward and right directions
            Vector3 cameraForward = cameraTransform.forward;
            Vector3 cameraRight = cameraTransform.right;

            // Normalize to prevent unintended diagonal movement speeds
            cameraForward.y = 0;
            cameraRight.y = 0;
            cameraForward.Normalize();
            cameraRight.Normalize();

            // Calculate movement direction relative to the camera
            Vector3 move = (cameraForward * moveZ + cameraRight * moveX).normalized;

            // Move the player based on input
            rb.MovePosition(transform.position + move * moveSpeed * Time.deltaTime);

            // Rotate the player to face the movement direction if there is input
            if (move != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(move);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
