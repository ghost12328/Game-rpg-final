using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;    // The maximum health of the player
    public float currentHealth;       // The current health of the player

    void Start()
    {
        // Initialize current health to max health at the start
        currentHealth = maxHealth;
    }

    // Method to reduce health when the player takes damage
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
            currentHealth = 0;

        // You can call other methods here like checking if the player is dead
    }

    // Method to heal the player
    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }

    // Method to check if the player is alive
    public bool IsAlive()
    {
        return currentHealth > 0;
    }
}
