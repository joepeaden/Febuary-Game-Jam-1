using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRanged : SkillsSuper
{
    void Awake()
    {
        skillName = "Ranged Attack";
        description = "Attacks enemies from range.";
        energyCost = 0;
    }

    override
    public void SkillAction(GameObject target)
    {
        Debug.Log("Select enemy to attack with a ranged attack!");

        // Wait for enemy selection

        // Attack enemy

        // Remove energy 

        // exit
    }
}
