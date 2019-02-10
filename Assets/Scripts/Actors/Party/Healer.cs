using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : ActorSuper
{
    void Awake()
    {
        charName = "Healer"; 

        maxHealth = 100;
        health = maxHealth;

        maxEnergy = 100;
        energy = maxEnergy;

        skills = new SkillsSuper[3];
        skills[0] = new BasicMelee();
        skills[1] = new BasicRanged();
        skills[2] = new HealPartyMember();
    }
}
