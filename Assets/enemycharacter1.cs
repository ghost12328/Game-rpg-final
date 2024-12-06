using UnityEngine;

public class EnemyCharacter : Character
{
    private ExitManager exitManager;

    void Start()
    {
        // Find the ExitManager in the scene
        exitManager = FindObjectOfType<ExitManager>();
    }

    // Override the Die method for the enemy
    protected override void Die()
    {
        Debug.Log("Enemy has been defeated.");

        // Notify the ExitManager that an enemy has been defeated
        if (exitManager != null)
        {
            exitManager.EnemyDefeated();
        }

        // Handle enemy death here (e.g., destroy enemy object)
        Destroy(gameObject); // Destroys the enemy GameObject when health is zero
    }
}
