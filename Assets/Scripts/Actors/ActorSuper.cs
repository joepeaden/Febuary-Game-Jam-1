using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActorSuper : MonoBehaviour
{
    protected string charName;

    protected float maxHealth;
    protected float health;

    protected float maxEnergy;
    protected float energy;

    protected SkillsSuper[] skills;

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health < 0)
            Death();
    }

    public void GainHealth(float healed)
    {
        health += healed;

        if (health > maxHealth)
            health = maxHealth;
    }

    public void UseEnergy(float lost)
    {
        energy -= lost;

        if (energy < 0)
            energy = 0;
    }

    public void GainEnergy(float recovered)
    {
        energy += recovered;

        if (energy > maxEnergy)
            energy = maxEnergy;
    }

    private void Death()
    {
        Debug.Log("Player has died!");
        Destroy(this);
    }
}
