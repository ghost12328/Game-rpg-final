using UnityEngine;

public class FireEnemy : EnemyCharacter  // Ensure it's referring to the correct class
{
    public float fireDamage = 10f;
    private PlayerHealth playerHealth;  // Reference to the player's health script

    void Start()
    {
        // Find the player and get their PlayerHealth script
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Additional FireEnemy-specific behavior
    public void FireAttack()
    {
        // Fire attack logic, for example:
        Debug.Log("FireEnemy attacks with fire!");

        // Deal fire damage to the player if the player exists
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(fireDamage);  // Subtract fire damage from player's health
        }
    }

    // You can call FireAttack from somewhere else, like in Update or another method.
}
