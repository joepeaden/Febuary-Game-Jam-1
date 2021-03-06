﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActorSuper : MonoBehaviour
{
    public string charName;

    public float maxHealth;
    public float health;

    public float maxEnergy;
    public float energy;

    public SkillsSuper[] skills;

    private CombatManager cm;

    private void Start()
    {
        cm = FindObjectOfType<CombatManager>();
    }

    public void TakeDamage(float damage)
    {
        Debug.Log(damage);

        health -= damage;

        Debug.Log(charName + " has taken damage: " + health + " health remaining");

        if (health <= 0)
            Death();
    }

    public void GainHealth(float healed)
    {
        health += healed;

        if (health > maxHealth)
            health = maxHealth;
    }

    public float GetHealth()
    {
        return health;
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
        Debug.Log(charName + " has died!");
        Destroy(gameObject);
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            cm.SetTarget(gameObject);
        }
    }
}
