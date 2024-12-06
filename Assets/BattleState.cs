using UnityEngine;

public abstract class BattleState
{
    protected TurnBasedCombatSystem combatSystem;
    protected GameObject player;
    protected GameObject enemy;

    public BattleState(TurnBasedCombatSystem combatSystem, GameObject player, GameObject enemy)
    {
        this.combatSystem = combatSystem;
        this.player = player;
        this.enemy = enemy;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}
