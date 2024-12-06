using UnityEngine;

public class PlayerTurn : BattleState
{
    public PlayerTurn(TurnBasedCombatSystem combatSystem, GameObject player, GameObject enemy)
        : base(combatSystem, player, enemy) {}

    public override void Enter()
    {
        Debug.Log("Player's turn. Choose an action.");
        combatSystem.UpdateCombatText("Player's Turn: Press Space to Attack");
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))  // Example: space key to attack
        {
            float damage = 20f;  // Example damage amount
            Debug.Log("Player attacks!");
            enemy.GetComponent<Character>().TakeDamage(damage);  // Deal 20 damage to the enemy
            combatSystem.DisplayDamageTaken(damage, false);  // Show enemy damage in combat text

            // Switch to enemy's turn after attacking
            combatSystem.SetState(new EnemyTurn(combatSystem, player, enemy));

            // Check if enemy is dead, end battle
            if (!enemy.GetComponent<Character>().IsAlive())
            {
                combatSystem.EndBattle();
            }
        }
    }

    public override void Exit()
    {
        // Cleanup or reset UI elements, if needed
    }
}
