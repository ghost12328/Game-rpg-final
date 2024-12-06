using UnityEngine;

public class PlayerCharacter : Character
{
    protected override void Die()
    {
        Debug.Log("Player has died.");
        // Handle player death, like restarting or game over
    }

    // You can add player-specific logic like movement, special attacks, etc.
}
