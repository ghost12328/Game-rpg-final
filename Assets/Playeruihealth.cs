using UnityEngine;
using UnityEngine.UI;  // Required for UI Text

public class HealthDisplay : MonoBehaviour
{
    public Text healthText;  // Reference to the UI Text component
    private PlayerHealth playerHealth;  // Reference to the PlayerHealth script

    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (playerHealth != null && healthText != null)
        {
            // Update the health text to display the player's current health
            healthText.text = "Health: " + playerHealth.currentHealth.ToString();
        }
    }
}
