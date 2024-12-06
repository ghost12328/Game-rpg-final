using UnityEngine;

public class ExitManager : MonoBehaviour
{
    public GameObject exit;  // The exit GameObject to be enabled
    public int enemiesToDefeat;  // Number of enemies that need to be defeated to reveal the exit
    private int defeatedEnemiesCount = 0;  // Counter for how many enemies have been defeated

    void Start()
    {
        // Ensure the exit is hidden initially
        exit.SetActive(false);

        // Validate the `enemiesToDefeat` value to ensure it is realistic
        if (enemiesToDefeat <= 0)
        {
            Debug.LogWarning("The number of enemies to defeat is set to zero or less. The exit will appear immediately.");
        }
    }

    // This method should be called when an enemy is defeated
    public void EnemyDefeated()
    {
        defeatedEnemiesCount++;
        Debug.Log("Enemy defeated! Total defeated: " + defeatedEnemiesCount);

        // Check if the required number of enemies have been defeated
        if (defeatedEnemiesCount >= enemiesToDefeat)
        {
            Debug.Log("Required number of enemies defeated! The exit is now available.");
            exit.SetActive(true);  // Show the exit
        }
    }
}
