using UnityEngine;

public class BattleStart : BattleState
{
    // Call the base class constructor
    public BattleStart(TurnBasedCombatSystem combatSystem, GameObject player, GameObject enemy)
        : base(combatSystem, player, enemy) {}

    public override void Enter()
    {
        Debug.Log("Battle has started!");
        // Show battle UI or trigger animations here if needed
    }

    public override void Update()
    {
        // Transition to the player's turn
        combatSystem.SetState(new PlayerTurn(combatSystem, player, enemy));
    }

    public override void Exit()
    {
        // Cleanup UI elements, if any
    }
}
