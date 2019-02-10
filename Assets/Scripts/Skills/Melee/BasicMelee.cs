using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMelee : SkillsSuper
{
    void Awake()
    {
        skillName = "Melee Attack";
        description = "Attacks enemies within a short range.";
        energyCost = 0;
    }

    override
    public void SkillAction(GameObject target)
    {
        Debug.Log("Select enemy to attack with melee!");

        target.GetComponent<ActorSuper>().TakeDamage(30f);

        // Wait for enemy selection

        // Attack enemy

        // Remove energy 

        // exit
    }
}
