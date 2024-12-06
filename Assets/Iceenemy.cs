using UnityEngine;

public class IceEnemy : EnemyCharacter  // Ensure it's referring to the correct base class
{
    public float iceDamage = 8f;  // Amount of damage dealt by the ice attack
    private PlayerHealth playerHealth;  // Reference to the player's health script

    void Start()
    {
        // Find the player and get their PlayerHealth script
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Additional IceEnemy-specific behavior
    public void IceAttack()
    {
        // Ice attack logic
        Debug.Log("IceEnemy attacks with ice!");

        // Deal ice damage to the player if the player exists
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(iceDamage);  // Subtract ice damage from player's health
        }
    }

    // You can call IceAttack from somewhere else, like in Update or another method.
}
