using UnityEngine;

public class BattleEnd : BattleState
{
    public BattleEnd(TurnBasedCombatSystem combatSystem, GameObject player, GameObject enemy) : base(combatSystem, player, enemy) { }

    public override void Enter()
    {
        Debug.Log("Battle has ended.");
      //   combatSystem.UpdateCombatText("Battle has ended.");
        // Remove the enemy from the scene
        if (enemy != null)
        {
            GameObject.Destroy(enemy);
            Debug.Log("Enemy has been defeated and removed from the scene.");
        }

        // Re-enable player movement
        combatSystem.EnablePlayerMovement();
    }

    public override void Update()
    {
        // Optionally, you could add logic here for displaying victory text or triggering other events.
    }

    public override void Exit()
    {
        Debug.Log("Exiting Battle End state.");
    }
}
