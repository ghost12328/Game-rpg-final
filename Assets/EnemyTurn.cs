using UnityEngine;

public class EnemyTurn : BattleState
{
    public EnemyTurn(TurnBasedCombatSystem combatSystem, GameObject player, GameObject enemy)
        : base(combatSystem, player, enemy) {}

    public override void Enter()
    {
        Debug.Log("Enemy's turn. Enemy attacks!");
        combatSystem.UpdateCombatText("Enemy's Turn: Enemy attacks!");
    }

    public override void Update()
    {
        if (enemy != null && player != null)
        {
            // Check if the enemy is of type FireEnemy or IceEnemy
            FireEnemy fireEnemy = enemy.GetComponent<FireEnemy>();
            IceEnemy iceEnemy = enemy.GetComponent<IceEnemy>();

            if (fireEnemy != null)
            {
                // If the enemy is a FireEnemy, use the FireAttack method
                fireEnemy.FireAttack();
            }
            else if (iceEnemy != null)
            {
                // If the enemy is an IceEnemy, use the IceAttack method
                iceEnemy.IceAttack();
            }
            else
            {
                // Otherwise, apply generic damage
                float damage = 15f;  // Example damage amount for the enemy's attack
                Debug.Log("Enemy attacks the player!");
                player.GetComponent<Character>().TakeDamage(damage);  // Deal damage to the player
                combatSystem.DisplayDamageTaken(damage, true);  // Show player damage in combat text
            }

            // Switch to the player's turn after enemy's attack
            combatSystem.SetState(new PlayerTurn(combatSystem, player, enemy));

            // Check if player is dead, end battle
            if (!player.GetComponent<Character>().IsAlive())
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
