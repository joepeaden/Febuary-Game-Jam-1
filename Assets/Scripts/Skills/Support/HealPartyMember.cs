using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPartyMember : SkillsSuper
{
    void Awake()
    {
        skillName = "Heal Party Member";
        description = "Heal a party member for 60 hp.";
        energyCost = 0;
    }

    override
    public void SkillAction()
    {
        Debug.Log("Select a teammate to heal!");

        // Wait for enemy selection

        // Attack enemy

        // Remove energy 

        // exit
    }
}
