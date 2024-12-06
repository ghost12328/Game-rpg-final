using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    public bool IsAlive()
    {
        return currentHealth > 0;
    }

    // Method to handle taking damage, to be called from the TurnBasedCombatSystem or other scripts
    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
    }

    // Abstract method to handle death (implemented in PlayerCharacter and EnemyCharacter)
    protected abstract void Die();
}
