using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private TurnBasedCombatSystem combatSystem;

    void Start()
    {
        // Get the TurnBasedCombatSystem reference from the scene (make sure it's attached to a manager or similar)
        combatSystem = FindObjectOfType<TurnBasedCombatSystem>();
        if (combatSystem == null)
        {
            Debug.LogError("TurnBasedCombatSystem not found in the scene.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the battle area (using the player's tag or name)
        if (other.CompareTag("Player") && combatSystem != null)
        {
            combatSystem.StartBattle(gameObject); // Start the battle with this enemy
        }
    }
}
