using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public float healAmount = 20f;  // Amount of health to restore

    void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Find the PlayerHealth component on the player object
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            // If the player has a PlayerHealth component, heal the player
            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount);  // Heal the player by the specified amount
                Destroy(gameObject);  // Destroy the health item after use
            }
            else
            {
                Debug.LogWarning("Player does not have PlayerHealth script.");
            }
        }
    }
}
