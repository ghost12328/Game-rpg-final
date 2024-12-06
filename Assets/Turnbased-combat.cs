using UnityEngine;
using UnityEngine.UI; // For legacy Text support

public class TurnBasedCombatSystem : MonoBehaviour
{
    public GameObject player;  // Reference to the player object
    private Character playerCharacter;
    private Character currentEnemyCharacter;
    public Text combatText; // Drag and drop your Text UI component here
    public ExitManager exitManager; // Reference to the ExitManager script

    private BattleState currentState;
    private bool isBattleInProgress = false; // Flag to check if a battle is ongoing

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player is not assigned in the Inspector!");
            return;
        }

        // Ensure the player has the Character component
        playerCharacter = player.GetComponent<Character>();
        UpdateCombatText("Prepare to fight!");
    }

    void Update()
    {
        // Call the update of the current state only if a battle is in progress
        if (isBattleInProgress)
        {
            currentState?.Update();
        }
    }

    // Set the current state
    public void SetState(BattleState state)
    {
        currentState?.Exit();
        currentState = state;
        currentState.Enter();
    }

    // Start battle with the current enemy
    public void StartBattle(GameObject enemy)
    {
        if (isBattleInProgress) return; // Prevent starting a new battle if one is in progress

        isBattleInProgress = true; // Mark the battle as in progress
        currentEnemyCharacter = enemy.GetComponent<Character>(); // Get the current enemy's character
        Debug.Log("Battle started. Player's turn.");
        SetState(new BattleStart(this, player, enemy));
        UpdateCombatText("Battle started. Player's turn.");
        DisablePlayerMovement();
    }

    // End the battle (when enemy is defeated, or player wins)
    public void EndBattle()
    {
        if (!isBattleInProgress) return; // Make sure battle is ongoing

        if (currentEnemyCharacter.IsAlive())
        {
            SetState(new BattleEnd(this, player, currentEnemyCharacter.gameObject));
            UpdateCombatText("Battle ended.");
        }
        else
        {
            // Enemy defeated, allow movement and move on to the next phase
            Debug.Log("The enemy has been defeated!");
            UpdateCombatText("The enemy has been defeated!");
            EnablePlayerMovement();  // Enable player movement after victory

            // Notify the ExitManager that an enemy has been defeated
            if (exitManager != null)
            {
                exitManager.EnemyDefeated();
            }
            else
            {
                Debug.LogWarning("ExitManager not assigned in TurnBasedCombatSystem!");
            }

            Destroy(currentEnemyCharacter.gameObject); // Remove the enemy from the scene
            isBattleInProgress = false; // Mark battle as over
        }
    }

    // Restart the game if the player dies
    public void RestartGame()
    {
        Debug.Log("Player is dead. Restarting game...");
        UpdateCombatText("Player is dead. Restarting game...");
        // Reload the scene here if necessary (SceneManager.LoadScene() for example)
    }

    // Disable player movement
    public void DisablePlayerMovement()
    {
        player.GetComponent<Rigidbody>().isKinematic = true; // Assuming you are using Rigidbody for movement
    }

    // Enable player movement
    public void EnablePlayerMovement()
    {
        player.GetComponent<Rigidbody>().isKinematic = false; // Enable movement
    }

    // Update combat text on the screen
    public void UpdateCombatText(string message)
    {
        if (combatText != null)
        {
            combatText.text = message;
        }
        else
        {
            Debug.LogWarning("Combat text UI element is not assigned!");
        }
    }

    // Display damage taken by either player or enemy
    public void DisplayDamageTaken(float damage, bool isPlayer)
    {
        string message = isPlayer ? $"Player took {damage} damage!" : $"Enemy took {damage} damage!";
        UpdateCombatText(message);
    }
}
