using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMelee : SkillsSuper
{
    private float damage = 30f;

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

        // Attack enemy
        target.GetComponent<ActorSuper>().TakeDamage(damage);

        Debug.Log(target.GetComponent<ActorSuper>().charName + "'s hp: " + target.GetComponent<ActorSuper>().health);
    }

    /*
    //override
    public bool ViableAction(GameObject enemyLocs, GameObject partyLocs, int width)
    {
        // Build grid
        int rows = (enemyLocs.transform.childCount + partyLocs.transform.childCount) / width;
        List<List<bool>> grid;

        for (int i = 0; i < rows; i++)
        {
            List<bool> row = new ArrayList();
            for (int j = 0; j < width; j++)
            {

            }
            grid(i).add();
        }

        // Find bounds

        // check

        return true;
    }*/
}
