using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinWarrior : ActorSuper
{
    void Awake()
    {
        charName = "Goblin Warrior";

        maxHealth = 80;
        health = maxHealth;

        maxEnergy = 100;
        energy = maxEnergy;

        skills = new SkillsSuper[1];
        skills[0] = new BasicMelee();
    }
}
